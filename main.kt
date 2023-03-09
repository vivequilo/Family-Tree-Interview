/**
 * You can edit, run, and share this code.
 * play.kotlinlang.org
 */

 class Node(
    val id: Int,
    val name: String,
    val parentId: Int?
) {
    var parent: Node? = null

    var right: Node? = null
    set(value: Node?){
        field = value
        if(value != null){
            value.parent = this
        }
    }

    var left: Node? = null
    set(value: Node?){
        field = value
        if(value != null){
            value.parent = this
        }
    }

    fun setNode(node: Node){
        if(this.left == null){
            this.left = node
        }else{
            this.right = node
        }
    }
}

fun getTree(list: List<Node>) : Node? {
    val nodes = hashMapOf<Int, Node>()
    var root: Node? = null
    list.forEach { node ->
        nodes[node.id] = node
        if(node.parentId == null){
            root = node
        }
    }

    nodes.forEach { (key, node) -> 
        node.parentId?.let { parentId ->
            nodes.get(parentId)?.setNode(node)
        }
    }
    return root
}




fun main(args: Array<String>) : Unit {
    val treeJson = listOf(
        Node(1, "Pedro A", null),
        Node(2, "Pedro H", 1),
        Node(3, "Lorena", 1),
        Node(4, "Luis", 2),
        Node(5, "Jimena", 3),
        Node(6, "Lucia", 2),
        Node(7, "Augusto", 6),
        Node(8, "Hsing Li", 6),
        Node(9, "Carmen", 8),
        Node(10,"Gabriel", 7),
        Node(11,"Juan", 7),
        Node(12,"Isabella", 5),
        Node(13,"Cristina", 5),
        Node(14,"Julia", 10),
        Node(15,"Javier", 11),
    )

    val root = getTree(treeJson)

    if(root == null){
        print("No se logro resolver el root")
        return
    }
    
    
}