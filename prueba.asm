;Archivo: Prueba.cpp
;Fecha: 08/11/2022 07:35:55 p. m.
#make_COM#
include 'emu8086.inc'
ORG 100h
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
MOV AX, 0
PUSH AX
POP AX
MOV i, AX
while1 :
MOV AX, i
PUSH AX
MOV AX, 10
PUSH AX
POP BX
POP AX
CMP AX, BX
JGE finWhile1
PRINT "*"
INC i
JMP while1
finWhile1:
RET
DEFINE_SCAN_NUM
DEFINE_PRINT_NUM
DEFINE_PRINT_NUM_UNS
END
