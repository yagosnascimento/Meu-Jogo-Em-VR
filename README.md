# Meu Jogo em VR

Um jogo frenético em Realidade Virtual desenvolvido na Unity. O objetivo é simples: gerenciar uma esteira e colocar os objetos corretos dentro das caixas correspondentes.

## O Jogo

Neste projeto de VR, você precisa de agilidade e raciocínio rápido para não deixar o caos tomar conta.

* **Acertou a caixa?** Você ganha pontos e ganha mais tempo para continuar jogando.
* **Deixou cair no void?** Você é penalizado perdendo pontos e tempo.

## Funcionalidades Principais

* **Física de Esteira:** Sistema customizado (`Esteira.cs`) que movimenta os objetos de forma contínua e interativa.
* **Sistema de Pontuação e Tempo:** Lógica de risco e recompensa (`ScoreManager.cs` e `ScoreTrigger.cs`) que pune erros e premia acertos dinamicamente.
* **Leaderboard:** Sistema de registro de pontuação (`LeadeboardManager.cs`) para acompanhar quem sobreviveu mais tempo.
* **Void Destruidor:** Deixou passar? O `Destruidor.cs` cuida de eliminar o objeto e aplicar a penalidade no seu tempo e score.
* **Integração VR:** Configurado com o *XR Interaction Toolkit* para uma experiência imersiva e responsiva com as mãos.

## Arte e Modelagem 3D

Um dos maiores diferenciais deste projeto é que **100% dos modelos 3D foram criados por mim**. 

Desde os componentes da esteira (`Esteira.fbx`, `Conveyor Belt.fbx`) até os recipientes de coleta (`Caixas.fbx`, `Caixa.glb`), todo o design visual e a estética *low poly* foram modelados do zero para garantir a melhor performance e identidade visual em VR.

## Tecnologias Utilizadas

* **Engine:** Unity (C#)
* **VR Framework:** XR Interaction Toolkit
* **Modelagem 3D:** Criado de forma autoral para otimização em Realidade Virtual.

---

**Autor:** Desenvolvido por Yago Nascimento.
