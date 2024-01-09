using System;
using System.Collections.Generic;


public class Node
{
    string name;
    int id;
    int? parentId;
    
    Node left;
    
    Node right;
    
    Node parent;
    
    public Node(int id, string name, int? parentId)
   {
      this.name = name;
      this.id = id;
      this.parentId = parentId;
      this.left = null;
      this.right = null;
   }
   
   public void setNode(Node node){
       if(this.left == null){
            this.left = node;
        }else{
            this.right = node;
        }
   } 
   
   public int? getParentId() {
       return parentId;
   }
   
   public int getId() {
       return id;
   }
   
    public Node getLeft(){
        return left;
    }
    
    public Node setLeft(Node left){
        left.parent = this;
        this.left = left;
        return left;
    }
    
      
    public Node getRight(){
        return right;
    }
    
    public Node setRight(Node right){
        right.parent = this;
        this.right = right;
        return right;
    }
}

public class HelloWorld
{
    
    public static Node getTree(Node[] list) {
        Dictionary<int, Node> nodes = new Dictionary<int, Node>();
    
        Node root = null;
        for (int i = 0; i < list.Length; i++) 
        {
            Node node = list[i];
            nodes[node.getId()] = node;
            if (node.getParentId() == null) {
                root = node;
            }
        }
        
      for (int i = 0; i < list.Length; i++) 
        {
            Node node = list[i];
            int parentId;
            if(node.getParentId() != null){
                parentId = (int)node.getParentId();
            }else{
                parentId = -1;
            }
             
            if (parentId != -1) {
                nodes[parentId].setNode(node);
            }
        }
    
        return root;
    }   
    
    public static void Main(string[] args)
    {


        Node[] treeJson = new Node[15];

        treeJson[0] = new Node(1,"Pedro A", null);
        treeJson[1] = new Node(2,"Pedro H", 1);
        treeJson[2] = new Node(3,"Lorena", 1);
        treeJson[3] = new Node(4,"Luis", 2);
        treeJson[4] = new Node(5,"Jimena", 3);
        treeJson[5] = new Node(6,"Lucia", 2);
        treeJson[6] = new Node(7,"Augusto", 6);
        treeJson[7] = new Node(8,"Hsing Li", 6);
        treeJson[8] = new Node(9,"Carmen", 8);
        treeJson[9] = new Node(10,"Gabriel", 7);
        treeJson[10] = new Node(11,"Juan", 7);
        treeJson[11] = new Node(12,"Isabella", 5);
        treeJson[12] = new Node(13,"Cristina", 5);
        treeJson[13] = new Node(14,"Julia", 10);
        treeJson[14] = new Node(15,"Javier", 11);
        
        Node root = getTree(treeJson);
        
        
    }
}
