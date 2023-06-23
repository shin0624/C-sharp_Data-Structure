using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Exercise
{//노드 기반 트리 구현

    class TreeNode<T>
    {
        public T Data { get; set; }//정점 노드 Data
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();//정점 노드에 연결된 자식들

    }
    class Tree_Implementation
    {

        static TreeNode<string> MakeTree()
        {
            TreeNode<string> root = new TreeNode<string>() { Data = "R1 개발실" };
            {
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "디자인팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "전투" });
                    node.Children.Add(new TreeNode<string>() { Data = "경제" });
                    node.Children.Add(new TreeNode<string>() { Data = "스토리" });
                    root.Children.Add(node);
                   
                }
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "프로그래밍팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "서버" });
                    node.Children.Add(new TreeNode<string>() { Data = "클라이언트" });
                    node.Children.Add(new TreeNode<string>() { Data = "엔진" });
                    root.Children.Add(node);
                   
                }
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "아트팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "배경" });
                    node.Children.Add(new TreeNode<string>() { Data = "캐릭터" });
                    root.Children.Add(node);
                   
                }
            }
            return root;
        }

        static void PrintTree(TreeNode<string> root)
        {
            //접근-->재귀함수로 트리 출력
            Console.WriteLine(root.Data);

            foreach(TreeNode<string>child in root.Children)
                PrintTree(child);

        }

        static int GetHeight(TreeNode<string> root)//트리의 높이 반환
        {
            int height = 0;

            foreach (TreeNode<string> child in root.Children)
            {
                int newHeight = GetHeight(child)+1;
                if(height<newHeight) height = newHeight;

                //height = Math.Max(height, newHeight);-->height와 newheight중 큰 값을 height에 저장. 이렇게 하는 방법이 가독성이 더 높음.
            }

            return height;
        }


        static void Main(string[] args)
        {
            TreeNode<string> root = MakeTree();

            PrintTree(root);

            Console.WriteLine(GetHeight(root));
            GetHeight(root);
        }


    }
}