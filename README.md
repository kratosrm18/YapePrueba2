# Proyecto de Pruebas Automatizadas de la app Booking.com

Este proyecto implementa un framework de pruebas automatizadas para aplicaciones Android utilizando Gherkin, SpecFlow, C#, Appium y Allure Report. El objetivo es proporcionar una estructura robusta y extensible para validar las funcionalidades de la aplicación móvil Booking.com.

## Tabla de Contenidos

- [Introducción](#introducción)
- [Requisitos](#requisitos)
- [Herramientas Utilizadas](#herramientas-utilizadas)

## Introducción

Este proyecto utiliza un stack compuesto por Gherkin, SpecFlow, C#, Appium y Allure Report para realizar pruebas automatizadas de aplicaciones Android. Cada herramienta ha sido seleccionada cuidadosamente para proporcionar un entorno de pruebas eficiente y fácil de mantener.

## Requisitos

- [Visual Studio](https://visualstudio.microsoft.com/) con el plugin SpecFlow for Visual Studio
- .NET Core SDK
- [Appium Server](http://appium.io/)
- Dispositivo Android o emulador configurado
- Node.js para la instalación de Appium

## Herramientas Utilizadas
### Gherkin
Por qué Gherkin:
Gherkin se utiliza para escribir los escenarios de pruebas en un lenguaje entendible por todos los stakeholders (incluidos los no técnicos). Permite describir el comportamiento esperado de la aplicación en un formato de Given-When-Then.

### SpecFlow
Por qué SpecFlow:
SpecFlow es la implementación de Cucumber para .NET. Permite vincular las descripciones en Gherkin con el código de pruebas en C#, facilitando el desarrollo dirigido por comportamiento (BDD).

### C#
Por qué C#:
C# es un lenguaje de programación robusto y ampliamente utilizado en el desarrollo de aplicaciones. Su uso en este proyecto permite aprovechar las características del ecosistema .NET y una sólida integración con Visual Studio.

### Appium
Por qué Appium:
Appium es una herramienta de automatización de pruebas para aplicaciones móviles. Es compatible con múltiples plataformas (iOS, Android) y permite escribir pruebas en cualquier lenguaje que tenga soporte para Selenium WebDriver, como C# en este caso.

### Allure Report
Por qué Allure Report:
Allure Report es una herramienta flexible y ligera para generar informes de ejecución de pruebas. Proporciona informes visuales detallados que facilitan el análisis de los resultados de las pruebas.
