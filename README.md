##Series Angular

### Commits

Desde la misma aplicación de escritorio puedes realizar los commits, procura especificar cuales son los objetivos que ha abordado y no subir nunca cosas que no compilen o dificulten a los demas el trabajo.  

Para añadir cambios al repositorio externo de manera manual en linux hay que hacerlo en 3 pasos:

1. Tenemos que añadir los cambios realizados al repositorio ejecutando el siguiente comando en la raiz de nuestro proyecto:  
	```sh
	$ git add -A
	```
    Con esto añadimos todos los archivos del proyecto al repositorio, los que no han sido modificados no se tendran en cuenta.

2. Luego toca confirmar los cambios, antes de hacer esto combiene saber que cambios se van a realizar y como esta el 	repositorio, para ello ejecutamos el comando:  
	```sh
	$ git status
	```
	Si queremos volver a como estabamos realizamos:
	```sh
	$ git reset HEAD
	```
	para confirmar los cambios escribimos:
	```sh
	$ git commit -m "Comentario sobre lo que se ha implementado"
	```

3. Finalmente lo subimos todo al repositorio externo:
	```sh
	$ git push origin master
	```
