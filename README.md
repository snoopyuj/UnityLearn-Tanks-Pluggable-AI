#  Tanks Pluggable AI
Pluggable AI With Scriptable Objects [(Official Tutorial)](https://www.youtube.com/watch?v=cHUXh5biQMg&list=PLX2vGYjWbI0ROSj_B0_eir_VkHrEkd4pi&index=1)

> *Author: Fork from [@ricardosanz97](https://github.com/ricardosanz97/TanksPluggableAI/tree/master)*
> *Created: May 13, 2023*  
> *Tags: C#, Unity3D*
> *Unity Version: 2019.4.40f1*

## Structure
```
State Controller (Mono)
  State
    Actions (Patrol, Chase, Attack)
    Transitions
      Decision (Look, Scan)
      True State
      False State

=== Example: Chaser AI ===
Patrol Chase State*
  Patrol Action
  if (Look Decision)
    Chase Chaser State* (Next State)
  else
    Remain In State

Chase Chaser State*
  Chase Action + Attack Action
  if (Active State Decision)
    Remain In State
  else
    Patrol Chaser State* (Go back to default)
```

## Notes
* We need to separate State files if the next states are different
* e.g. `Patrol Chase State` and `Patrol Scanner State`
* It use for loop to iterate Transitions, the new result will overwrite the previous one