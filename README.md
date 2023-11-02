# learningProject_2DFighting

For my second Unity project, I also followed an online tutorial. This time, I'm working on a 2D platformer game. Since I have a game concept in mind that shares a similar game mechanic in the future, I want to build up my technical skills now. After completing the small project of Plants vs. Zombies, I have a basic understanding of Unity, so this tutorial didn't prove to be too challenging on my first day of development. Given the daily academic pressures, I only allocate a portion of my time each day to work on these projects – there's also the need to study for my thesis, graphics, and machine learning-related subjects.

## Development Day 1: 2023.10.18

I have to say, a good tutorial is indeed crucial. When the instructor's approach is clear, their code is well-structured, and their knowledge of Unity is deep, the quality of their teaching is exceptionally high. This time, the instructor has made me feel comfortable and provided clear guidance compared to the instructor from the first tutorial. I have learned a lot from following this instructor and taken plenty of notes. Here are some of the specific topics I covered (excluding detailed content):

1. I learned about the relevant parameters and functions of **Rigidbody** in Unity, as well as the differences between Box Collider and Capsule Collider. I also learned why Capsule Collider is often preferred.
1. I learned how to access and manipulate objects in Unity's engine through code. Previously, I only knew that I could search for objects within the game entities, but today I learned that I can directly assign the relevant entities by dragging and dropping them into the public variables in the corresponding script. Of course, I still prefer the flexibility and versatility of accessing entities through code because it's not limited to public variables. However, this operation has given me a clearer understanding of Unity's engine workflow.
1. I learned that in Unity, you can directly access key information by using the name associated with a bound key. For example, if the "space" key is bound to "Jump," you can use `GetButtonDown("Jump")` to check whether the space key is pressed. This significantly improves development efficiency. You can find the specific configuration in the corresponding options within the Project Manager.
1. I also learned about the significance of layers in Unity. We added a new layer, and these layers have a specific rendering order, starting from layer 0, with each new layer placed above all the previous layers. This mechanism helps us efficiently manage the development order of 2D games without having to worry about adjusting the entire layer order when adding new entities.



## Development Day 2: 2023.10.19

Today, I accomplished character movement and implemented a simple camera follow feature, which also involved background movement. The work I completed was quite extensive. In the process, I also learned a lot about how to operate and understand the principles of the Animator. Some of the newer points I learned include:

1. Creating sprite animations involves first slicing the sprite sheets and then adding the individual frames of the sliced sprites into an Animation.

2. In the Animator, there's a "Flip" option that allows you to horizontally or vertically flip 2D sprite animations. To do this, you need to first access the sprite rendering component, **SpriteRenderer**, and then use its flip functionality. The component also offers other features that are worth exploring in more detail.

   Accessing Components: 

   ```c#
   theSR = GetComponent<SpriteRenderer>();
   ```

   To invoke the sprite flipping functionality:

   ```C#
   if(theRB.velocity.x < 0) 
   {
       theSR.flipX = true;
   } else if (theRB.velocity.x > 0)
   {
       theSR.flipX = false;
   }
   ```

3. The method used to create a convincing parallax scrolling effect for the background is quite clever yet simple. It involves moving different layers of the background at different, but coordinated speeds. The tutorial provided detailed instructions for this. For instance, objects in the far distance move the same distance as the character, while closer elements move at a slower pace, perhaps at 0.5 times the character's speed. You can further consider how to handle this if you have a very large and long map because creating an extremely long and repetitive background is not the most efficient use of time and resources.

   Here is some of the code:

   ```c#
   float amountToMoveX = transform.position.x - lastXPos;
   farBackground.position = farBackground.position + new Vector3(amountToMoveX,0f,0f);
   middleBackground.position += new Vector3(amountToMoveX * 0.5f, 0f, 0f);
   
   lastXPos = transform.position.x;
   ```

4. I also used a physicsMaterial2D to eliminate friction, preventing the character from sticking to the environment. Additionally, by selecting "Collision Detection" as "Continuous," I implemented a feature that calculates whether objects will collide before the collision occurs, allowing them to stop before entering each other.

## Development Day 3: 2023.10.26

Today, I learned a few new things. One of them is how to use sprite sheets to create 2D maps, which will be very useful in future development. I even drew my first map, and it feels great. Secondly, I studied some aspects of camera following in 2D games and gained insights into the principles of implementing various mechanisms, including invincibility frames.



## Development Day 4: 2023.10.28

Today I sat in front of the computer all day and got more and more addicted. By now, I feel like I have a general idea of the content of Unity, but I’m more interested in how the teacher thinks about all the mechanisms and expressions, and how to make the game more detailed. However, I still learned a lot today. I learned how to create item pickups and how to convert special effects. After careful consideration, I found that when implementing an animation that only plays once, one way is to destroy the object after a certain amount of time, and fix the animation execution time to a certain period. Then, before the animation finishes playing and enters the next round of looping, you can destroy the game entity used by the animation.

Another knowledge is to put several sprite maps in a game entity, which can make it easier to operate jumping or three-dimensional moving game characters.



## Development Day 5: 2023.10.29

Today is the fifth day of development, and the sound effects part of the game has been completed. Starting tomorrow, we will begin to create some game panels. The tutorial is really well taught. The knowledge points learned today are listed below:

1. Animation curves in Animator

2. Adding restrictions in code

   ```C#
       [Range(0,100)] public float chanceToDrop; //[Range(0,100)] restricts the value of chanceToDrop to be between 0-100
   ```

3. Unity3D sound controls

   1. Sound play and stop
   2. Sound adjustment: pitch
   3. AudioMixer

4. Settings for UI buttons and sprite configuration:

   1. In Sprite, you can set a central area to automatically complete the surrounding edge graphics by cutting.
   2. The Pannel component in UI.

5. Unity scene switching and level design.

6. Time.timeScale

## Development Day 6: 2023.10.30

The new knowledge points I came across today are as follows:

1. The overlay function of two layers in TileMap.
2. The difference between GetAxisRaw and GetAxis: GetAxis returns a value that gradually increases from 0 to 1, while GetAxisRaw only returns 0 or 1.
3. Vector3.MoveTowards and Mathf.MoveTowards



## Development Day 7: 2023.10.31

Today, I implemented the functionality of creating a new game and continuing a game from the main interface, completed the development of level selection, and finally created two game entities in the game: platform and moving platform. The new knowledge points I came across today are as follows:

1. Setting **PlayerPrefs** to implement storage and loading.
2. **Raycast Target**, if checked, means that this layer can be clicked and will mask the content behind it.
3. **Edge Collider**: A collider with only one line.
4. **Platform Effector**: Adds effects to the platform, can set one-way platform function, its displayed semicircular graphic prompt indicates that the game entity entering from the side corresponding to the semicircular arc will collide with the platform, and those entering from the side of the semicircular radius will not.
5. Designed a moving platform using **OnCollisionEnter2D** API.

## Development Day 8: 2023.11.1

Today, I clearly realized the matter about Collider. The function OnTriggerEnter2D is bound to the game entity bound by the C# script. If it is to be triggered, this game entity must add a Collider. The Collider of a child object cannot trigger the function of the parent object, and similarly, the collider of the parent object cannot trigger the function on the child object.

 The new knowledge points I came across today are as follows:

1. [Header(“Movement”)]: You can add variable partitions in the Unity panel to make variable lookup more convenient. It cannot be used when there are no variables in the following text. If you add a Header to a statement that declares multiple variables, it will add this Header to each variable.

   ```
       [Header("Shooting")]//Normal declaration
       public GameObject bullets;
       public Transform firePoint;
       public float timeBetweenShots;
       private int bulletCounter;
       
       [Header("Movement")]//Adding a Header to a statement that declares multiple variables
       public Transform leftPoint, rightPoint;
       
       [Header("Hurt")]//Incorrect declaration
   	(No variables follow)
   ```

2. When you only want some programs to run in Unity for debugging and do not want players to use them, you can use:

   ```
   #if UNITY_EDITOR
   	......
   #endif
   ```

## Development Day 9: 2023.11.2

The development has ended, but rather than saying it’s over, it’s more like after learning a lot, it’s time to look for a new beginning.

These past few days, I’ve really benefited a lot from this tutorial. My understanding of Unity has become more detailed and systematic. If this was the first tutorial I learned from, perhaps I wouldn’t have felt so uncomfortable at the beginning.

However, I do have a few small questions about this tutorial, perhaps because I just started developing games and am not very familiar with the overall style of the code. One is that there are too many nested if statements in this tutorial. I remember the deepest one had four layers of nesting. This “nesting hell” honestly would have confused me if I had to think about it myself. I also tried to optimize a few nests, but in the end, I chose to focus on learning Unity and just went with the flow. The second one comes from the teacher’s coding habits. In the entire 113-episode tutorial, the teacher only wrote one line of comments. There’s no problem for teaching, but in the later stages, if I didn’t add comments when following along, I would be dazzled by the search - the teacher didn’t have any, which shows a high level of skill. The third one is the teacher’s general way of solving problems. The teacher’s way of solving problems is somewhat like brute force, so there are many variables, and they are sorted out one by one with if statements. Later on, I thought carefully and realized that this method is the fastest and most effective way, even if there are a lot of variable names. However, this is normal for object-oriented languages.

 The new knowledge points I came across today are as follows:

1. If you just want to change the direction of a character in a 2D game, you can flip the sprite image to get it. If you want to flip along with the child objects, you can set the value of the flip axis in Scale of the parent object to its opposite number (e.g., set x from 1 to -1 when flipping horizontally).
2. Vector3.one: It’s a vector of (0,0,0).
