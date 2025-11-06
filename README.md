# AI Repository 7th semester

## Doggy FSM vs BT

Doggy AI which Follows player when near him and returns home after being abandoned (evil behaviour from your part)

It works using and comparing its position with the player's and setting its destination to either home or to the player depending on the distance between them and the time passed after the player left the poor doggy behind >:(

### Good things about FSM:
* Modular design let me recycle previously used states and conditions in different ways
* Access to EnterState and ExitState
### Bad things about FSM:
* Although modular specific states or conditions needed to be created as Scriptable objects made it slower

### Good things about BT:
* I was able to name the tree doggy :D
* Simple script needed to make a functional behaviour tree with the occassional creation of strategies kept creation of behaviour tree simpler (subjective)
* Abliliy to assign simple tasks through delegates is faster than creating a new state
 
### Bad things about BT:
* Sequences can require multiple parameters to setup

As I've previously mentioned FSMs (specifically modular ones) are very useful in the creation of entities with similar behaviours with the possibility to change some behaviours because of its reusability, but Behaviour trees work really well in a specific environment and needs if reusable states are not a priority, making it most likely the best choice in making a simple dog, unless you were to make several entities including and not limited to Juan 

<img width="835" height="532" alt="image" src="https://github.com/user-attachments/assets/d66b6c0e-c468-4220-846c-18ce7ea9a99c" />
