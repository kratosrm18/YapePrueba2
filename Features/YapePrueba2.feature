Feature: Escenarios para la app Booking.com
!Prueba tecnica para postular a Yape
Por indicacion de la prueba se diseñará un escenario E2E que recorrerá el flujo completo del servicio de alojamiento.
Tambien algunos unhappy paths.
Los escenarios serán diseñados de forma imperativa

Background: 
	Given El usuario accede a la app

@HappyPath
Scenario: CP01_Flujo de reserva hasta la pasarela de pago
	Given El usuario busca CUSCO como destino
	And Selecciona las fechas 14/10/2024 al 28/10/2024
	And Selecciona 1 habitacion 2 adultos y un nino de 5 anos
	When Selecciona el boton APPLY
	When Selecciona el boton Search
	And Selecciona el segundo resultado
	And Selecciona el boton Select rooms
	And Selecciona la primera opcion de habitacion
	And Selecciona el boton Reserve
	And Llena los datos del formulario
	And Selecciona boton Next step
	Then Se visualizan los datos de la reserva
	When Selecciona boton Final step
	Then Se visualiza el formulario de tarjeta de credito
	
@UnhappyPath
Scenario: CP02_No se puede realizar busqueda sin seleccionar destino
	When Selecciona el boton Search
	Then Visualiza alerta de ingresar destino

@UnhappyPath
Scenario: CP03_Formulario vacio no permite continuar
	Given El usuario busca CUSCO como destino
	And Selecciona las fechas 14/10/2024 al 28/10/2024
	And Selecciona 1 habitacion 2 adultos y un nino de 5 anos
	When Selecciona el boton APPLY
	When Selecciona el boton Search
	And Selecciona el segundo resultado
	And Selecciona el boton Select rooms
	And Selecciona la primera opcion de habitacion
	And Selecciona el boton Reserve
	And Selecciona boton Next step
	Then Se visualiza alerta de ingresar su nombre