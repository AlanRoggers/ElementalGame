Hasta ahora tengo tres "Order in Layer" La primera la uso para las decoraciones, la segunda para el terreno y la tercera para el personaje.
Nota: La numeración es 0, 1, 2, 3 y mientras mas grande es el número, el dibujo saldrá por encima de los números más bajos.

Valores para los scripts del jugador:

Movimiento Horizontal:
-Move Force = 20
-Weight = 100
Para el caso de la friccion, quiero hacer varios casos:
-Tag = "Terrain" la friccion estoy viendo que funciona bien con 1 pero tengo que seguir probando
-Tag = "Air" la friccion aún no la eh puesto
-Tag = "Ice" la friccion aún no la eh puesto

Movimiento Vertical:
-Jump Force = 30

Collision Detector
-FeetFix en Y = 0.01
-KickPosFix X = 0.57 Y = 0.56
-KickSizeFix X = 0.325 Y = 0.46

Cuando se utilizan TileMaps y se va a realizar los colliders automaticos con Tilemap Collider 2D parece ser que el valor
por defecto de Offset distance da problemas, lo puse en cero y todo va bien

