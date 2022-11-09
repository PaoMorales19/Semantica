;Archivo: Prueba.cpp
;Fecha: 09/11/2022 05:45:09 p. m.
#make_COM#
include 'emu8086.inc'
ORG 100h
MOV AX, 0
PUSH AX
POP AX
MOV i, AX
Do1 :
;hola
PRINT "hola"
INC i
MOV AX, i
MOV i, AX
MOV AX, i
PUSH AX
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP AX, BX
JGE finDo1
JMP Do1
finDo1:
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
