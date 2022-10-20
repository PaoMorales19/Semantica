using System;
//Ana Paola Morales Anaya
//Requerimiento 1: Actualizacion
//                  a) Agregar el residuo de la división en el porFactor
//                  b) Agregar en Instruccion los incrementos de termino y los incremetos de Factor
//                      a++, a--, a+=1, a-=1, a*=1; a/=1; a%=1
//                      en donde el 1 puede ser une expresion
//                  c) Programar el destructor 
//                  #libreria especial? contenido? en la clase lexico
//                  Para ejecutar el método cerrarArchivo
//Requerimiento 2: Actualizacion
//                  c) Marcar errores semanticos cuando los incrementos de termino o incrementosFactor superen el rango de la variable
//                  d)Considerar el inciso b) y c) para el for
//                  e)Hacer que funcione el while y el do while
//Requerimiento 3: 
namespace Semantica
{
    public class Lenguaje : Sintaxis
    {
        List<Variable> variables = new List<Variable>();
        Stack<float> stack = new Stack<float>();
        Variable.TipoDato Dominante;
        public Lenguaje()
        {

        }
        public Lenguaje(string nombre) : base(nombre)
        {

        }
        ~Lenguaje()//Destructor
        {
            Console.WriteLine("Destructor");
            cerrar();
        }
        private void addVariable(string nombre, Variable.TipoDato tipo)
        {
            variables.Add(new Variable(nombre, tipo));
        }
        private void displayVariables()
        {
            log.WriteLine();
            log.WriteLine("Variables: ");
            foreach (Variable v in variables)
            {
                log.WriteLine(v.getNombre() + " " + v.getTipo() + " " + v.getValor());
            }
        }
        private bool existeVariable(string nombre)
        {
            foreach (Variable v in variables)
            {
                if (v.getNombre().Equals(nombre))
                {
                    return true;
                }
            }
            return false;
        }
        private void modVariable(string nombre, float nuevoValor)
        {
            foreach (Variable L in variables)
            {
                if (L.getNombre().Equals(nombre))
                {
                    L.setValor(nuevoValor);
                }
            }

        }
        private float getValor(string nombreVariable)//foreach
        {
            foreach (Variable L in variables)
            {
                if (L.getNombre().Equals(nombreVariable))
                {
                    return L.getValor();
                }
            }
            return 0;
        }

        private Variable.TipoDato getTipo(string nombre)//foreach
        {
            foreach (Variable v in variables)
            {
                if (v.getNombre().Equals(nombre))
                {
                    return v.getTipo();
                }
            }
            return Variable.TipoDato.Char;
        }
        //Programa  -> Librerias? Variables? Main
        public void Programa()
        {
            Libreria();
            Variables();
            Main();
            displayVariables();
        }

        //Librerias -> #include<identificador(.h)?> Librerias?
        private void Libreria()
        {
            if (getContenido() == "#")
            {
                match("#");
                match("include");
                match("<");
                match(Tipos.Identificador);
                if (getContenido() == ".")
                {
                    match(".");
                    match("h");
                }
                match(">");//if (getContenido() == "#")
                Libreria();
            }
        }

        //Variables -> tipo_dato Lista_identificadores; Variables?
        private void Variables()
        {
            if (getClasificacion() == Tipos.TipoDato)
            {
                Variable.TipoDato tipo = Variable.TipoDato.Char;
                switch (getContenido())
                {
                    case "int":
                        tipo = Variable.TipoDato.Int;
                        break;
                    case "float":
                        tipo = Variable.TipoDato.Float;
                        break;
                }
                match(Tipos.TipoDato);
                Lista_identificadores(tipo);
                match(Tipos.FinSentencia);
                Variables();
            }
        }

        //Lista_identificadores -> identificador (,Lista_identificadores)?
        private void Lista_identificadores(Variable.TipoDato tipo)
        {
            if (getClasificacion() == Tipos.Identificador)
            {
                if (!existeVariable(getContenido()))
                {
                    addVariable(getContenido(), tipo);
                }
                else
                {
                    throw new Error("Error de sintaxis, variable duplicada <" + getContenido() + "> en linea: " + linea, log);
                }
            }
            match(Tipos.Identificador);
            if (getContenido() == ",")
            {
                match(",");
                Lista_identificadores(tipo);
            }
        }
        //Main      -> void main() Bloque de instrucciones
        private void Main()
        {
            match("void");
            match("main");
            match("(");
            match(")");
            BloqueInstrucciones(true);
        }

        //Bloque de instrucciones -> {lista de intrucciones?}
        private void BloqueInstrucciones(bool evaluacion)
        {
            match("{");
            if (getContenido() != "}")
            {
                ListaInstrucciones(evaluacion);
            }
            match("}");
        }

        //ListaInstrucciones -> Instruccion ListaInstrucciones?
        private void ListaInstrucciones(bool evaluacion)
        {
            Instruccion(evaluacion);
            if (getContenido() != "}")
            {
                ListaInstrucciones(evaluacion);
            }
        }

        //ListaInstruccionesCase -> Instruccion ListaInstruccionesCase?
        private void ListaInstruccionesCase(bool evaluacion)
        {
            Instruccion(evaluacion);
            if (getContenido() != "case" && getContenido() != "break" && getContenido() != "default" && getContenido() != "}")
            {
                ListaInstruccionesCase(evaluacion);
            }
        }

        //Instruccion -> Printf | Scanf | If | While | do while | For | Switch | Asignacion
        private void Instruccion(bool evaluacion)
        {
            if (getContenido() == "printf")
            {
                Printf(evaluacion);
            }
            else if (getContenido() == "scanf")
            {
                Scanf(evaluacion);
            }
            else if (getContenido() == "if")
            {
                If(evaluacion);
            }
            else if (getContenido() == "while")
            {
                While(evaluacion);
            }
            else if (getContenido() == "do")
            {
                Do(evaluacion);
            }
            else if (getContenido() == "for")
            {
                For(evaluacion);
            }
            else if (getContenido() == "switch")
            {
                Switch(evaluacion);
            }
            else
            {
                Asignacion(evaluacion);
            }
        }
        private Variable.TipoDato evaluaNumero(float resultado)
        {
            if (resultado % 1 != 0)
            {
                return Variable.TipoDato.Float;
            }
            if (resultado <= 256)
            {
                return Variable.TipoDato.Char;
            }
            else if (resultado == 65536)
            {
                return Variable.TipoDato.Int;
            }
            return Variable.TipoDato.Float;
        }
        private bool evaluaSemantica(string variable, float resultado)
        {
            Variable.TipoDato tipoDato = getTipo(variable);
            return false;
        }

        //Asignacion -> identificador = cadena | Expresion;
        private void Asignacion(bool evaluacion)
        {
            string nombre = getContenido();
            if (!existeVariable(getContenido()))
            {
                throw new Error("ERROR DE SINTAXIS: Variable no declarada <" + getContenido() + "> en linea: " + linea, log);
            }
            log.WriteLine();
            log.Write(getContenido() + " = ");
            match(Tipos.Identificador);
            Dominante = Variable.TipoDato.Char;
            if (getClasificacion() == Tipos.IncrementoTermino || getClasificacion() == Tipos.IncrementoFactor)
            {
                //Requerimiento 1b)
                //Requerimiento 1c)
            }
            else
            {
                match(Tipos.Asignacion);
                
                Expresion();
                match(";");
                float resultado = stack.Pop();
                log.Write(" = " + resultado);
                log.WriteLine();
                if (Dominante < evaluaNumero(resultado))
                {
                    Dominante = evaluaNumero(resultado);
                }
                if (Dominante <= getTipo(nombre))
                {
                    if (evaluacion)
                    {
                        modVariable(nombre, resultado);
                    }
                }
                else
                {
                    throw new Error("Error de semantica: no podemos asignar un: <" + Dominante + "> a un <" + getTipo(nombre) + "> en linea  " + linea, log);
                }
            }

            // modVariable(nombre, resultado);
        }

        //While -> while(Condicion) bloque de instrucciones | instruccion
        private void While(bool evaluacion)
        {
            match("while");
            match("(");
            bool ValidarWhile = Condicion();
            if (!evaluacion)
            {
                ValidarWhile = false;
            }
            match(")");
            if (getContenido() == "{")
            {
                if (ValidarWhile)
                {
                    BloqueInstrucciones(evaluacion);
                }
                else
                {
                    BloqueInstrucciones(false);
                }

            }
            else
            {
                if (ValidarWhile)
                {
                    Instruccion(evaluacion);
                }
                else
                {
                    Instruccion(false);
                }
            }
        }

        //Do -> do bloque de instrucciones | intruccion while(Condicion)
        private void Do(bool evaluacion)
        {
            bool ValidarDo = true;
            if (!evaluacion)
            {
                ValidarDo = false;
            }
            match("do");
            if (getContenido() == "{")
            {
                BloqueInstrucciones(evaluacion);
            }
            else
            {
                Instruccion(evaluacion);
            }
            match("while");
            match("(");

            ValidarDo = Condicion();
            match(")");
            match(";");
        }
        private float IncrementoDelFor(bool evaluacion)
        {
            string variable = getContenido();
            if (!existeVariable(getContenido()))
            {
                throw new Error("ERROR DE SINTAXIS: Variable no declarada <" + getContenido() + "> en linea: " + linea, log);
            }
            match(Tipos.Identificador);
            if (getContenido() == "++")//le puse un +
            {
                match("++");
                if (evaluacion)
                {
                    //modVariable(variable, getValor(variable) + 1);
                    return getValor(variable) + 1;
                }
            }
            else if (getContenido() == "--")
            {
                match("--");
                if (evaluacion)
                {
                    //modVariable(variable, getValor(variable) - 1);
                    return getValor(variable) - 1;
                }

            }
            return getValor(variable);
        }

        //For -> for(Asignacion Condicion; Incremento) BloqueInstruccones | Intruccion 
        private void For(bool evaluacion)
        {
            match("for");
            match("(");
            Asignacion(evaluacion);
            bool ValidarFor;
            int posicion2 = posicion;
            int lineaG = linea;
            int tamano = getContenido().Length;
            do
            {
                ValidarFor = Condicion();
                if (!evaluacion)
                {
                    ValidarFor = false;
                }
                match(";");
                string nIncremento = getContenido();
                float incremento = IncrementoDelFor(ValidarFor);
                //Requerimiento 1d)
                match(")");
                if (getContenido() == "{")
                {
                    BloqueInstrucciones(ValidarFor);
                }
                else
                {
                    Instruccion(ValidarFor);
                }
                if (ValidarFor)
                {
                    posicion = posicion2 - tamano;
                    linea = lineaG;
                    setPosicion(posicion);
                    NextToken();
                    modVariable(nIncremento, incremento);
                }
            } while (ValidarFor);
        }
        private void setPosicion(int posicion)
        {
            archivo.DiscardBufferedData();
            archivo.BaseStream.Seek(posicion, SeekOrigin.Begin);
        }
        //Incremento -> Identificador ++ | --
        private void Incremento(bool evaluacion)
        {
            string variable = getContenido();
            if (!existeVariable(getContenido()))
            {
                throw new Error("ERROR DE SINTAXIS: Variable no declarada <" + getContenido() + "> en linea: " + linea, log);
            }
            match(Tipos.Identificador);
            if (getContenido() == "++")//le puse un +
            {
                match("++");
                if (evaluacion)
                {
                    modVariable(variable, getValor(variable) + 1);
                }
            }
            else if (getContenido() == "--")
            {
                match("--");
                if (evaluacion)
                {
                    modVariable(variable, getValor(variable) - 1);
                }
            }
        }

        //Switch -> switch (Expresion) {Lista de casos} | (default: )
        private void Switch(bool evaluacion)
        {
            match("switch");
            match("(");
            Expresion();
            stack.Pop();
            match(")");
            match("{");
            ListaDeCasos(evaluacion);
            if (getContenido() == "default")
            {
                match("default");
                match(":");
                if (getContenido() == "{")
                {
                    BloqueInstrucciones(evaluacion);
                }
                else
                {
                    Instruccion(evaluacion);
                }
            }
            match("}");
        }//
        //ListaDeCasos -> case Expresion: listaInstruccionesCase (break;)? (ListaDeCasos)?
        private void ListaDeCasos(bool evaluacion)
        {
            match("case");
            Expresion();
            stack.Pop();
            match(":");
            ListaInstruccionesCase(evaluacion);
            if (getContenido() == "break")
            {
                match("break");
                match(";");
            }
            if (getContenido() == "case")
            {
                ListaDeCasos(evaluacion);
            }
        }

        //Switch -> switch (Expresion) {Lista de casos} | (default: ) //Condicion -> Expresion operador relacional Expresion
        private bool Condicion()
        {
            Expresion();
            string operador = getContenido();
            match(Tipos.OperadorRelacional);
            Expresion();
            float e2 = stack.Pop();
            float e1 = stack.Pop();
            switch (operador)
            {
                case "==":
                    return e1 == e2;
                case ">":
                    return e1 > e2;
                case ">=":
                    return e1 >= e2;
                case "<":
                    return e1 < e2;
                case "<=":
                    return e1 <= e2;
                default:
                    return e1 != e2;
            }
        }

        //If -> if(Condicion) bloque de instrucciones (else bloque de instrucciones)?
        private void If(bool evaluacion)
        {
            match("if");
            match("(");
            bool validarIf = Condicion();
            if (evaluacion == false)
            {
                validarIf = false;
            }

            match(")");
            if (getContenido() == "{")
            {
                BloqueInstrucciones(validarIf);
            }
            else
            {
                Instruccion(validarIf);
            }
            if (getContenido() == "else")
            {
                match("else");
                if (getContenido() == "{")
                {
                    if (evaluacion)
                    {
                        BloqueInstrucciones(!validarIf);
                    }
                    else
                    {
                        BloqueInstrucciones(false);
                    }
                }
                else
                {
                    if (evaluacion)
                    {
                        Instruccion(!validarIf);
                    }
                    else
                    {
                        Instruccion(false);
                    }

                }
            }
        }

        //Printf -> printf(cadena);
        private void Printf(bool evaluacion)
        {

            match("printf");
            match("(");
            if (getClasificacion() == Tipos.Cadena)
            {
                if (evaluacion)
                {
                    string cadena;
                    cadena = getContenido().Replace("\"", "").Replace("\\n", "\n").Replace("\\t", "\t");
                    Console.Write(cadena);
                }
                match(Tipos.Cadena);
            }
            else
            {
                Expresion();
                float resultado = stack.Pop();
                if (evaluacion)
                {
                    Console.Write(resultado);
                }
            }
            match(")");
            match(";");
        }

        //Scanf -> scanf(cadena, &Identificador);
        private void Scanf(bool evaluacion)
        {
            match("scanf");
            match("(");
            match(Tipos.Cadena);
            match(",");
            match("&");
            if (!existeVariable(getContenido()))
            {
                throw new Error("ERROR DE SINTAXIS: Variable no declarada <" + getContenido() + "> en linea: " + linea, log);
            }
            string nombreVariable = getContenido();

            if (evaluacion == true)
            {
                string val = "" + Console.ReadLine();
                try
                {
                    float val2 = float.Parse(val);
                    modVariable(nombreVariable, val2);
                }
                catch (Exception)
                {
                    throw new Error("Error de Sintaxis, no se puede asignar <" + getContenido() + ">  linea " + linea, log);
                }

            }
            match(Tipos.Identificador);
            match(")");
            match(";");
        }
        //Expresion -> Termino MasTermino
        private void Expresion()
        {
            Termino();
            MasTermino();
        }
        //MasTermino -> (OperadorTermino Termino)?
        private void MasTermino()
        {
            if (getClasificacion() == Tipos.OperadorTermino)
            {
                string operador = getContenido();
                match(Tipos.OperadorTermino);
                Termino();
                log.Write(operador + " ");
                float n1 = stack.Pop();
                float n2 = stack.Pop();

                switch (operador)
                {
                    case "+":
                        stack.Push(n2 + n1);
                        break;
                    case "-":
                        stack.Push(n2 - n1);
                        break;

                }
            }
        }
        //Termino -> Factor PorFactor
        private void Termino()
        {
            Factor();
            PorFactor();
        }
        //PorFactor -> (OperadorFactor Factor)? 
        private void PorFactor()
        {
            if (getClasificacion() == Tipos.OperadorFactor)
            {
                string operador = getContenido();
                match(Tipos.OperadorFactor);
                Factor();
                log.Write(operador + " ");
                float n1 = stack.Pop();
                float n2 = stack.Pop();
                //Requerimiento 1.a)
                switch (operador)
                {
                    case "*":
                        stack.Push(n2 * n1);
                        break;
                    case "/":
                        stack.Push(n2 / n1);
                        break;
                }
            }
        }
        private float ValorCasteado(float N1, Variable.TipoDato casteo)
        {
            if (casteo == Variable.TipoDato.Char)
            {
                return N1 % 256;
            }
            else if (casteo == Variable.TipoDato.Int)
            {
                return N1 % 65536;
            }
            return N1;
        }
        //Factor -> numero | identificador | (Expresion)
        private void Factor()
        {
            if (getClasificacion() == Tipos.Numero)
            {
                log.Write(getContenido() + " ");
                if (Dominante < evaluaNumero(float.Parse(getContenido())))
                {
                    Dominante = evaluaNumero(float.Parse(getContenido()));
                }
                stack.Push(float.Parse(getContenido()));
                match(Tipos.Numero);
            }
            else if (getClasificacion() == Tipos.Identificador)
            {
                if (!existeVariable(getContenido()))
                {
                    throw new Error("ERROR DE SINTAXIS: Variable no declarada <" + getContenido() + "> en linea: " + linea, log);
                }
                log.Write(getContenido() + " ");

                if (Dominante < getTipo(getContenido()))//
                {
                    Dominante = getTipo(getContenido());//
                }
                stack.Push(getValor((getContenido())));//
                match(Tipos.Identificador);
            }
            else
            {
                bool huboCasteo = false;
                Variable.TipoDato casteo = Variable.TipoDato.Char;
                match("(");
                if (getClasificacion() == Tipos.TipoDato)//!=
                {
                    huboCasteo = true;
                    switch (getContenido())
                    {
                        case "char":
                            casteo = Variable.TipoDato.Char;
                            break;
                        case "int":
                            casteo = Variable.TipoDato.Int;
                            break;
                        case "float":
                            casteo = Variable.TipoDato.Float;
                            break;
                    }
                    match(Tipos.TipoDato);
                    match(")");
                    match("(");
                }
                Expresion();
                match(")");
                if (huboCasteo)
                {
                    float N1;
                    N1 = stack.Pop();
                    stack.Push(ValorCasteado(N1, casteo));
                    Dominante = casteo;
                }
            }
        }
    }
}