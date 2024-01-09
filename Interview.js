

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


//Helper function to build a tree from a list of JSON items
const getTree = (list) => {
    //Create a object to hold the mapping of the nodes
    let nodes = {}
    //Create a variable to store later the root of the whole tree
    let root = undefined
    //Iterate in the list of json elements
    list.forEach((json) => {
        //Create a new instance of the Node class from the json
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
