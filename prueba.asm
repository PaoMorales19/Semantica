;Archivo: Prueba.cpp
;Fecha: 09/11/2022 08:40:36 p. m.
#make_COM#
include 'emu8086.inc'
ORG 100h
MOV AX, 8
PUSH AX
POP AX
MOV i, AX
MOV AX, i
PUSH AX
POP AX
CALL PRINT_NUM
MOV AX, 2
PUSH AX
MOV AX, i
MOD AX, 2
MOV i, AX
