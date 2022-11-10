;Archivo: Prueba.cpp
;Fecha: 09/11/2022 10:29:48 p. m.
#make_COM#
include 'emu8086.inc'
ORG 100h
PRINT "Introduce la altura de la piramide: "
CALL SCAN_NUM
MOV altura, CX
MOV AX, altura
PUSH AX
MOV AX, 2
PUSH AX
POP BX
POP AX
CMP AX, BX
JLE if2
MOV AX, altura
PUSH AX
POP AX
MOV i, AX
Iniciofor1:
MOV AX, i
PUSH AX
MOV AX, 0
PUSH AX
POP BX
POP AX
CMP AX, BX
JLE finFor1
MOV AX, 0
PUSH AX
POP AX
MOV j, AX
while1:
MOV AX, j
PUSH AX
MOV AX, altura
PUSH AX
MOV AX, i
PUSH AX
POP BX
POP AX
SUB AX, BX
PUSH AX
POP BX
POP AX
CMP AX, BX
JGE finWhile1
JMP while1
finWhile1:
PRINTN ""
PRINT ""
SUB i, 1
JMP Iniciofor1
finFor1:
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
SUB AX, BX
PUSH AX
MOV AX, 0
PUSH AX
POP AX
MOV k, AX
Do1:
;hola
PRINT "-"
MOV AX, 2
PUSH AX
MOV BX, k
ADD BX, AX
MOV k, BX
MOV AX, k
PUSH AX
MOV AX, altura
PUSH AX
MOV AX, 2
PUSH AX
POP BX
POP AX
MUL BX
PUSH AX
POP BX
POP AX
CMP AX, BX
JGE finDo1
JMP Do1
finDo1:
PRINTN ""
PRINT ""
JMP else2
if2:
PRINTN ""
PRINTN "Error: la altura debe de ser mayor que 2"
PRINT ""
else2:
MOV AX, 1
PUSH AX
MOV AX, 1
PUSH AX
POP BX
POP AX
CMP AX, BX
JE if34
PRINT "Esto no se debe imprimir"
MOV AX, 2
PUSH AX
MOV AX, 2
PUSH AX
POP BX
POP AX
CMP AX, BX
JNE if36
PRINT "Esto tampoco"
JMP else36
if36:
else36:
JMP else34
if34:
else34:
MOV AX, 258
PUSH AX
POP AX
MOV a, AX
PRINT "Valor de variable int 'a' antes del casteo: "
MOV AX, a
PUSH AX
POP AX
CALL PRINT_NUM
MOV AX, a
PUSH AX
POP AX
POP AX
MOV y, AX
PRINTN ""
PRINT "Valor de variable char 'y' despues del casteo de a: "
MOV AX, y
PUSH AX
POP AX
CALL PRINT_NUM
PRINTN ""
PRINTN "A continuacion se intenta asignar un int a un char sin usar casteo: "
PRINT ""
;Variables: 
	area dd ?
	radio dd ?
	pi dd ?
	resultado dd ?
	a dw ?
	d dw ?
	altura dw ?
	cinco dw ?
	x dd ?
	y db ?
	i dw ?
	j dw ?
	k dw ?
RET
DEFINE_PRINT_NUM
DEFINE_PRINT_NUM_UNS
DEFINE_SCAN_NUM
END
