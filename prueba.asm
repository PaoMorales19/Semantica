;Archivo: Prueba.cpp
;Fecha: 07/11/2022 09:27:06 p. m.
#make_COME
#include emu8086.inc
ORG 1000h
;Variables: 
	area dd ?
	radio dd ?
	pi dd ?
	resultado dd ?
	a dw ?
	d dw ?
	altura dw ?
	x dw ?
	i dw ?
	j dw ?
	k dw ?
	l dw ?
	y dw ?
MOV AX, 1
PUSH AX
POP AX
MOV y, AX 
MOV AX, y
PUSH AX
POP AX
MOV AX, y
PUSH AX
MOV AX, 10
PUSH AX
POP AX
POP BX
CMP AX, BX
JGE finDo1
MOV AX, y
PUSH AX
POP AX
MOV AX, y
PUSH AX
MOV AX, 10
PUSH AX
POP AX
POP BX
CMP AX, BX
JGE finDo2
MOV AX, y
PUSH AX
POP AX
MOV AX, y
PUSH AX
MOV AX, 10
PUSH AX
POP AX
POP BX
CMP AX, BX
JGE finDo3
MOV AX, y
PUSH AX
POP AX
MOV AX, y
PUSH AX
MOV AX, 10
PUSH AX
POP AX
POP BX
CMP AX, BX
JGE finDo4
MOV AX, y
PUSH AX
POP AX
MOV AX, y
PUSH AX
MOV AX, 10
PUSH AX
POP AX
POP BX
CMP AX, BX
JGE finDo5
MOV AX, y
PUSH AX
POP AX
MOV AX, y
PUSH AX
MOV AX, 10
PUSH AX
POP AX
POP BX
CMP AX, BX
JGE finDo6
MOV AX, y
PUSH AX
POP AX
MOV AX, y
PUSH AX
MOV AX, 10
PUSH AX
POP AX
POP BX
CMP AX, BX
JGE finDo7
MOV AX, y
PUSH AX
POP AX
MOV AX, y
PUSH AX
MOV AX, 10
PUSH AX
POP AX
POP BX
CMP AX, BX
JGE finDo8
MOV AX, y
PUSH AX
POP AX
MOV AX, y
PUSH AX
MOV AX, 10
PUSH AX
POP AX
POP BX
CMP AX, BX
JGE finDo9
