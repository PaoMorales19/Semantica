;Archivo: Prueba.cpp
;Fecha: 13/11/2022 01:50:15 a. m.
#make_COM#
include 'emu8086.inc'
ORG 100h
;Variables: 
	area DW ?
	radio DW ?
	pi DW ?
	resultado DW ?
	a DW ?
	d DW ?
	altura DW ?
	cinco DW ?
	x DW ?
	y DW ?
	i DW ?
	j DW ?
	k DW ?
MOV AX, 4
PUSH AX
POP AX
MOV j, AX
MOV AX, j
PUSH AX
POP AX
CALL PRINT_NUM
MOV AX, 3
PUSH AX
POP AX
MOV AX, j
MOV BX, 3
DIV BX 
MOV j, DX
MOV AX, j
PUSH AX
POP AX
CALL PRINT_NUM
RET
DEFINE_PRINT_NUM
DEFINE_PRINT_NUM_UNS
DEFINE_SCAN_NUM
END
