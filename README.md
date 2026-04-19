# 📊 Sistema de Gestión de Tareas - Mini-Core UDLA

**Desarrollado por:** Eduardo Andrade  
**Institución:** Universidad de las Américas (UDLA)  
**Materia:** Ingeniería de Software  

---

## 🚀 Descripción del Proyecto
Este sistema es una solución integral basada en la arquitectura **ASP.NET Core MVC** diseñada para gestionar el progreso de tareas dentro de diversos proyectos. Su funcionalidad principal radica en la capacidad de monitorear avances y calcular desviaciones de tiempo de forma inteligente.

La aplicación permite filtrar tareas en estado *'En Progreso'* dentro de un rango de fechas seleccionado por el usuario, calculando automáticamente:

* **Fecha Estimada de Finalización:** Basada en el tiempo estimado (horas/días).
* **Días de Retraso:** Cálculo preciso que excluye sábados y domingos, reflejando la realidad de la jornada laboral.

---

## 🛠️ Tecnologías y Arquitectura
* **Arquitectura:** Model-View-Controller (MVC) con separación de responsabilidades.
* **Backend:** .NET 10 (C#) utilizando Entity Framework Core.
* **Base de Datos:** PostgreSQL (Alojada en Supabase).
* **Frontend:** Razor Pages, Bootstrap 5 y DataTables para una experiencia interactiva.
* **Despliegue:** Contenerización con Docker y Hosting en Render.

---

## 💻 Instalación y Ejecución Local
Si deseas probar este proyecto en tu máquina local, sigue estos pasos:

### 1. Requisitos Previos
* SDK de .NET 10.0.
* Instancia de PostgreSQL (o acceso a Supabase).
* Git.

### 2. Clonar el Repositorio
```bash
git clone https://github.com/edjam006/Tarea4_EjercicioMVC-Andrade.git
cd Tarea4_EjercicioMVC-Andrade
```

### 3. Configurar la Base de Datos
Edita el archivo `appsettings.json` y coloca tu cadena de conexión en la sección `DefaultConnection`.

### 4. Aplicar Migraciones
Ejecuta los siguientes comandos para crear la estructura de tablas y cargar los datos de prueba (Seeding):

```bash
dotnet ef database update
```

### 5. Ejecutar la Aplicación
```bash
dotnet run
```
La aplicación estará disponible en `http://localhost:5000` (o el puerto configurado).

---

## 🔗 Enlaces de Interés
* **Demo en Vivo:** [https://tarea4-ejerciciomvc-andrade.onrender.com](https://tarea4-ejerciciomvc-andrade.onrender.com)
* **Repositorio Original:** [GitHub](https://github.com/edjam006/Tarea4_EjercicioMVC-Andrade)

---
*© 2026 - Eduardo Andrade - Ingeniería de Software UDLA*
