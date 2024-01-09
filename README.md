# Entrevista Qüilo
## Algoritmo árbol genealógico 🌳

Actualmente una empresa necesita el desarrollo para poder hayar los descendientes de cierto nivel para una determinada persona en un árbol genealógico y lo han contratado a usted como freelancer para poder desarrollar dicho programa.

Le indican que tome en cuenta el hecho de que *cada integrante del árbol podrá tener únicamente dos hijos como máximo*.

## Instrucciones

Utilice la clase `Node` que se le brindará a continucación como base para el desarrollo de su algoritmo, siéntase libre de poder personalizar dicha clase a su conveniencia.

Se le otorgara un input de un array de objetos el cual se deberá de transformar en un árbol con apoyo de la función `getTree` (si se hace cambios en la clase `Node` que puedan afectar el funcionamiento de `getTree` tome en cuenta que debera de modificar `getTree` para continuar con su correcto funcionamiento).

Una vez con el árbol generado se le pedira que encuentre cualquier persona unicamente con su id.
Ej:
``` js
//id = 5
let findById = (id, tree) => tree.search(id) // Node(id: 5, name: "Soy le nodo con id 5")
```

Luego se le pide que proceda a encontrar los descendientes en cualquier nivel para determinado nodo dentro de una lista e imprimir un detalle de la misma.
Ej:
``` javascript
//level = 2
let findDescendants = (level,  tree) => tree.getDescendantsInLevel(level) //[Node(id: 1, name: "Nieto 1"), Node(id: 10, name: "Nieto 2")....]

//Lógica para imprimir el resultado
....
/**
* Los descendientes en el nivel numero 2 son:
* Nieto 1
* Nieto 2
* ...etc
*/
```


## Material de apoyo

Función `getTree`
``` js
//Helper function to build a tree from a list of JSON items
const getTree = (list) => {
    //Create a object to hold the mapping of the nodes
    let nodes = {}
    //Create a variable to store later the root of the whole tree
    let root = undefined
    //Iterate in the list of json elements
    list.forEach((json) => {
        Create a new instance of the Node class from the json
        let node = new Node(json)
        //We will map it using the id
        nodes[`${json.id}`] = node
        //If there is no parentId key in the json item it means is the root node
        if(!json.parentId){
            root = node
        }
    })

    //Iterate on each one of the keys of the nodes mapped
    Object.keys(nodes).map((id) => {
        //Retrieve the node from the map corresponding to the current key
        let node = nodes[id]
        //Check if it has a parent
        if(node.parentId){
            //Retrieve the parent from the map and set the relation
            nodes[`${node.parentId}`].setNode(node)
        }
    })
    return root
}
```

Clase `Node`
``` js
class Node
{
    constructor({ id, name, parentId })
    {
        this.id = id;
        this.name = name;
        this.parentId = parentId
        this.left = null;
        this.right = null;
        this.parent = null
    }

    setNode(node){
        if(!this.left){
            this.left = node
        }else{
            this.right = node
        }
    }

    get left(){
        return this._left
    }

    set left(node){
        this._left = node
        if(node){
            node.parent = this
        }
    }

    get right(){
        return this._right
    }

    set right(node){
        this._right = node
        if(node){
            node.parent = this
        }
    }
}
```

## Test input
``` js
let treeJson = [
    {id: 1, name: "Pedro A"},
    {id: 2, name: "Pedro H", parentId : 1},
    {id: 3, name: "Lorena", parentId : 1},
    {id: 4, name: "Luis", parentId : 2},
    {id: 5, name: "Jimena", parentId : 3},
    {id: 6, name: "Lucia", parentId : 2},
    {id: 7, name: "Augusto", parentId : 6},
    {id: 8, name: "Hsing Li", parentId : 6},
    {id: 9, name: "Carmen", parentId : 8},
    {id: 10, name: "Gabriel", parentId : 7},
    {id: 11, name: "Juan", parentId : 7},
    {id: 12, name: "Isabella", parentId : 5},
    {id: 13, name: "Cristina", parentId : 5},
    {id: 14, name: "Julia", parentId : 10},
    {id: 15, name: "Javier", parentId : 11},
]
```

Con el siguiente input al decidir jalar los descendientes en el segundo nivel del nodo con id `7`
se espera la siguiente lista como resultado:
``` js
[
Node(id: 14, name: "Julia"),
Node(id: 15, name: "Javier"),
]
```
