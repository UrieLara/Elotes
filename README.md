# 🌽 Elotes – Hunter Duck Mechanics (Unity 2D)

<p align="center">
  <img src="./demo_elotes.png" alt="Gameplay de Elotes" width="600"/>
</p>

<p align="center"><i>Dale clic a los patos... y a los elotes 🌽</i></p>

Un videojuego arcade que reinventa la mecánica clásica de Hunter Duck (1985) con físicas modernas, personalización y assets originales en pixel art.

El objetivo es simple: acumula la mayor cantidad de puntos antes de que se acabe el tiempo. Haz clic en los patos... y también en los elotes que aparecen en pantalla.

**🔗 Demo:** [Jugar en itch.io](https://urielara.itch.io/elotes)

---

## 🛠 Tecnologías

![Unity](https://img.shields.io/badge/Unity-2022.3+-000000?logo=unity)
![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp)

- **Unity 2D** (2022.3)
- **C#**

---

## 🎮 Características actuales

- ✅ Sistema de puntería y clic con mouse (referencia de posición del mouse para mostrar objetos bajo el cursor)
- ✅ Generación dinámica de patos y verduras
- ✅ Sistema de puntuación (score)
- ✅ Temporizador límite
- ✅ Animaciones básicas
- ✅ Feedback visual al acertar
- ✅ **Eventos en Unity** para comunicación desacoplada entre sistemas
- ✅ **ScriptableObjects** para configurar parámetros de niveles fácilmente
- ✅ **Corutinas** para control de tiempos (spawn, animaciones, retardos)

---

## 🧠 Lo que aprendí / Mi enfoque

- Implementar **lógica de click detection** en Unity 2D
- Manejar **generación dinámica de objetos** (Instantiate/Destroy)
- Sistema de **tiempo y puntuación**
- Uso de **eventos** para desacoplar sistemas
- **ScriptableObjects** como contenedores de datos de niveles
- **Corutinas** (`yield return new WaitForSeconds`) para acciones temporizadas
- Tomar la **referencia del mouse** para instanciar objetos donde se posiciona
- **Cuellos de botella:** Instantiate/Destroy afecta rendimiento → próximo paso: **Object Pooling**
- **Primeros pasos en pixel art** (personajes, entorno y elementos UI)

---

## 🖥️ Cómo ejecutarlo localmente

1. Clona el repositorio:
   ```bash
   git clone https://github.com/UrieLara/Elotes
2. Abre Unity (versión recomendada: 2022.3 o superior)
3. Abre la escena principal (MainMenu) desde Assets/Scenes/
4. Presiona Play ▶️
