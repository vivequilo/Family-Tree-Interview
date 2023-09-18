

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


let getTree = (list) => {
    let nodes = {}
    
    let root = undefined
    list.forEach((json) => {
        //Create the node from each one of the elements
        let node = new Node(json)
        //Map it into the json
        nodes[`${json.id}`] = node
        //If no parent means the root
        if(!json.parentId){
            root = node
        }
    })
    
    Object.keys(nodes).map((id) => {
        let node = nodes[id]
        if(node.parentId){
            //Assign the relations
            nodes[`${node.parentId}`].setNode(node)
        }
    })
    return root
}
