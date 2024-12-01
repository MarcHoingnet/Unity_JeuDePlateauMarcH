# Unity_JeuDePlateauMarcH
 
## Projet :
J'ai eu énormément de problème avec ce projet, je l'ai recommencé 3 fois mais j'ai quand même réussi a voir quelque chose de plutôt fonctionel
Pour la base, j'avais commencé a faire une zone avec un *Navmesh* et crée un target pour que mon personnage s'y rende avec une vitesse variable pour que l'on puisse voit toutes les etapes et la transition des animations entre elles. Après plusieurs tests et beaucoup de bug, j'ai décidé d'abandonné cette technique et de partir sur quelque chose de completement différent.
J'ai supprimé tout ça et j'ai décidé de faire un script qui permet au joueur de controller directement le personnage à sa guise, en appliquant gravité, rotation, mouvement etc...

Une fois que cela était fonctionnel et que mes animations marchaient, j'ai décidé d'y rajouter le saut quand le joueur appuie sur espace.
là où les animations de mouvements précédents se jouaient grâce à une variable Speed dans l'Animator, ici pour le saut c'est grâce à une boolean IsJumping, ce qui permet la transition entre les états.

Cependant, après 2 jours de recherches, certains bug perdurent sur le projet. Lorsque l'on saute, 2 états demeurent actifs en même temps, ce qui créer un mélange entre 2 animations.
Le seul moyen que j'ai toruvé pour réglé ce probleme, en créer encore plus... Le personnage allait dans le sol et se mettais en T-Pose, parfois il se bloquait, et j'en passe...
J'ai commencé à placer dans l'Animator une seconde animation Idle mais peu fonctionnelle.

PS: Le script NPCController n'est plus utilisé car il contient la 1ere version décrite plus haut qui ne fonctionnait pas assez.


## Questions :
**Demain vous arrivez dans un studio disposant d’un moteur que vous ne connaissez pas, de quoi avez-vous besoin pour intégrer le travail des graphistes dans votre proto ?**

Pour cela, j'aurai besoin de connaitre les spécificités du moteur liés au formats des fichiers pris en charge par exemple, concernant les pipelines graphiques ou encore les limitations techniques, pour comprenre comment le moteur gére les assets.
J'aurai aussi surement besoin des plug-ins nécessaire et de savoir comment ils fonctionnent, pour m'y accomoder et éviter toute erreur lié à ça.
J'aurai besoin idéalement d'une bonne organisaiton du travails des graphistes, à travers le nommage, les fichiers, le classement des textures, asset 3D, anim... tout cela pour s'assurer de ne pas perdre du temps inutilement et vérifier que tout le travail des graphiste fourni soit bien compatible.
Enfin, j'aurai besoin d'un exemple fonctionnel, une sorte de modèle pour comparer et me faire la main, observer la structure actuelle pour comprendre comment tout cela est intégré.
Le but principale est de gagner le plus de temps possible, d'éviter au maximum le nombre d'erreur facilement contournable, tout cela grâce a une bonne adaptation et une bonne collaboration au sein de l'équipe

**quelles questions posez-vous et à qui ?**
*Je discuterai avec les graphistes eux-même pour savoir :*
- quels formats ils utilisent ?
- y a t il des besoins spécifiques pour le rendu ?
- auraient t ils des recommandations ou des contraites dont je devrais être au courant concerant l'optimisaiton des assets ?
- Comment comptent-ils organiser leur travaux lors de l'envoi ?

*Je discuterai avec les developpeurs techniques pour savoir :*
- s'il y a des réglages necessaires à faire sur le moteur ?
- comment le moteur gère les assets graphiques ?
- comment ont-ils l'habitude de travailler avec les graphistes ?
- y a t il des pipelines automatiques ou bien des scripts d'importations ?

*Et je discuterai avec le lead du projet pour savoir :*
- quels sont les objectifs à atteindre pour ce prototype ?
- avec qui je vais être amené a collaborer ?
- qui pourra me venir en aide si j'ai des questions ?
- y a t il un logiciel, un lien, qui permet de suivre et de mettre a jour la gestion du projet et l'avancée des taches ?
- y a t il des références ou des exemples de qualités visuels attenduent pour ce projet ?

**Qu'ai-je retenu des animations ?"**
Il y a beaucoup de choses que j'ai retenu des animations dans les moteurs de jeu :
- j'ai compris l'utilisation des Finite State Machines, ils sont essentielles pour organiser une logique de transitions entre les animations. Ils servent aussi à la gestion des états grâce à des conditions qui peuvent faire passer un état à un autre.
- j'ai compris les différentes étapes dans les aniamtions et l'importance de bien les segmenter en fonction des besoins de gameplay.
- j'ai compris comment choisir et importer efficacement des animations (format, in place, ...) pour pouvoir s'en servir dans un moteur de jeu.

J'ai compris qu'Unreal et Unity avaient des points communs concerant les animations :
- Utilisation de graphes visuels pour connecter les animations et définir les transitions.
- Paramètres (float, bool, trigger) pour contrôler les transitions.
- Simplicité d'importation d'assets (FBX, Blend Trees).

il faut aussi faire attention à plusieurs choses qui peuvent apporter des problèmes facilement :
- Bien ajusté les courbes de transition (Animator / Blend Space)
- Bien utiliser le Root Motion pou lier le mouvement directement à l'animation 
- Bien organiser ses FSM en vérifiant les conditions et les priorités des transitions