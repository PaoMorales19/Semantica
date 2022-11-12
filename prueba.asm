;Archivo: Prueba.cpp
;Fecha: 12/11/2022 03:09:47 p. m.
#make_COM#
include 'emu8086.inc'
ORG 100h
;Variables: 
	areaDW ?
	radioDW ?
	piDW ?
	resultadoDW ?
	aDW ?
	dDW ?
	alturaDW ?
	cincoDW ?
	xDW ?
	yDW ?
	iDW ?
	jDW ?
	kDW ?
PRINT 'Introduce la altura de la piramide: '
CALL SCAN_NUM
MOV altura, CX
MOV AX, altura
PUSH AX
MOV AX, 2
PUSH AX
POP BX
POP AX
CMP AX, BX
JLE if1
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
MOV AX, 1
PUSH AX
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
PRINTN ''
PRINT ''
POP AX
SUB i, AX
JMP Iniciofor1
finFor1:
MOV AX, 0
PUSH AX
POP AX
MOV k, AX
Do1:
PRINT '-'
MOV AX, 2
PUSH AX
POP AX
ADD k, AX
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
PRINTN ''
PRINT ''
JMP else1
if1:
PRINTN ''
PRINTN 'Error: la altura debe de ser mayor que 2'
PRINT ''
else1:
MOV AX, 1
PUSH AX
MOV AX, 1
PUSH AX
POP BX
POP AX
CMP AX, BX
JE if2
PRINT 'Esto no se debe imprimir'
MOV AX, 2
PUSH AX
MOV AX, 2
PUSH AX
POP BX
POP AX
CMP AX, BX
JNE if3
PRINT 'Esto tampoco'
JMP else3
if3:
else3:
JMP else2
if2:
else2:
RET
DEFINE_PRINT_NUM
DEFINE_PRINT_NUM_UNS
DEFINE_SCAN_NUM
END
