# Proyecto Centro Psicopedagógico Madero 🧠💻

## Bienvenidos al repo oficial del sistema de gestión del Centro Psicopedagógico Madero.

> Acá estamos construyendo un sistema que va a manejar turnos, pacientes, profesionales, usuarios y todo lo que nos pidieron las psicopedagogas (y un poco más 😉).

## 🏗️ Flujo de trabajo

1. Cada integrante trabaja en su **rama de feature**:
    - `feature/usuarios`
    - `feature/pacientes`
    - `feature/profesionales`
    - `feature/turnos`
    - `feature/frontend`
    - `feature/database`
    - `feature/testing`

2. Las ramas se mergean a `develop` mediante **pull request**.
    - Nada va a `main` sin pasar por `develop`.
    - Los QA testean todo antes de dar el OK.

3. Cuando `develop` está estable, se mergea a `main`.

---

## 🚀 Responsables y tareas

| Parte | Responsable | Rama |
|-------|-------------|------|
| Usuarios y login | Nicolás Álvarez | `feature/usuarios` |
| Pacientes | Brian Romero | `feature/pacientes` |
| Profesionales | Fernando Santos | `feature/profesionales` |
| Turnos | Diego Díaz | `feature/turnos` |
| Frontend (UI/UX) | Martin chazarreta  | `feature/frontend` |
| Base de datos y modelos | Nicolás Álvarez| `feature/database` |
| Integración y testing | Martín Fernández | `feature/testing` |

---

## 🚦 Reglas básicas (para no romper nada):

✅ Siempre trabajar en la rama `feature/...` correspondiente  
✅ Siempre hacer pull request a `develop`, nunca directo a `main`  
✅ Los QA prueban todo antes de mergear  
✅ Si tenés dudas, preguntá en el grupo antes de meter cambios grandes  
✅ Los commits deben ser claros (no vale "cositas" 😜)

---

## 🛠️ Herramientas

- **Backend:** Python + Django REST framework
- **Frontend:** React.JS
- **DB:** PostgreSQL
- **Control de versiones:** Git + GitHub

---

¡A meterle con todo equipo! 🚀  
Cualquier duda, se pregunta por el grupo o por acá.  
El que rompe el `main`, invita las medialunas 🥐.
