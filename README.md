# 🌽 Elotes – Hunter Duck Mechanics (Unity 2D)

<p align="center">
  <img src="./demo_elotes.png" alt="Gameplay de Elotes" width="600"/>
</p>

<p align="center"><i>Dale clic a los patos... y a los elotes 🌽</i></p>

**Elotes** es un juego 2D inspirado en las mecánicas del clásico *Hunter Duck*. Desarrollado como proyecto para la materia **Motores de Desarrollo de Videojuegos Avanzados** (Unity).

El objetivo es simple: acumula la mayor cantidad de puntos antes de que se acabe el tiempo. Haz clic en los patos... y también en los elotes que aparecen en pantalla.

**🔗 Demo (próximamente):** [Jugar en itch.io](link-pendiente)

---

## 🛠 Tecnologías

![Unity](https://img.shields.io/badge/Unity-2022.3+-000000?logo=unity)
![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp)

- **Unity 2D** (2022.3)
- **C#**

---

## 🎮 Características actuales

- ✅ Sistema de puntería y clic con mouse
- ✅ Generación dinámica de patos y elotes
- ✅ Sistema de puntuación (score)
- ✅ Temporizador límite
- ✅ Animaciones básicas
- ✅ Feedback visual al acertar

## 🟡 En desarrollo (para entrega en mayo)

- 🎨 Menú principal
- 🎨 Mejora de animaciones
- 🎨 Assets originales (reemplazar los generados por IA)
- 🎨 Fondo dibujado por mí
- ⚡ Optimización: migrar de Instantiate/Destroy a **Object Pooling**

---

## 🧠 Lo que aprendí / Mi enfoque

- Implementar **lógica de click detection** en Unity 2D
- Manejar **generación dinámica de objetos** (Instantiate/Destroy)
- Sistema de **tiempo y puntuación**
- Identificar cuellos de botella: el uso excesivo de Instantiate/Destroy afecta el rendimiento → próximo paso: **Object Pooling**

---

## 🖥️ Cómo ejecutarlo localmente

1. Clona el repositorio:
   ```bash
   git clone https://github.com/UrieLara/Elotes
2. Abre Unity (versión recomendada: 2022.3 o superior)
3. Abre la escena principal desde Assets/Scenes/
4. Presiona Play ▶️
