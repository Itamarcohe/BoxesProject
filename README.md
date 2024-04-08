# BoxesProject

Welcome to BoxesProject, a sophisticated box management system designed for optimizing warehouse storage and retrieval operations. This project utilizes Data Structures and Algorithms, specifically AVL trees, to efficiently match boxes to user requests based on specific dimensions, ensuring the most suitable box is found for every need.

## Description

The BoxesProject is crafted as a class project focusing on the application of AVL trees to solve real-world problems in warehouse management. By implementing advanced data structures, the system can quickly identify the best box based on a given range of dimensions, thereby streamlining the storage and retrieval process. This approach not only enhances efficiency but also supports complex operations such as adding new box sizes, updating quantities, and facilitating user-driven searches for the optimal box match.

## Features

- **Efficient Box Matching**: Utilizes AVL trees to find the most suitable box for given dimensions with maximum efficiency.
- **Dynamic Inventory Management**: Supports adding, updating, and deleting box records based on size, ensuring accurate inventory tracking.
- **User Request Handling**: Allows users to query the system for boxes that match specific criteria, including size and quantity.
- **Optimized Storage Logic**: Implements logic to maintain optimal inventory levels, avoiding overstocking while ensuring availability.

## How It Works

- **AVL Tree Implementation**: At the core of the project is the AVLTree class, which manages the balanced tree structure to organize box data efficiently.
- **Box and Node Classes**: The Box class represents individual boxes, while the Node class facilitates the AVL tree structure, including operations like rotations to maintain balance.
- **Storage Management**: The Storage class integrates the AVL tree with application logic, handling operations like box insertion, deletion, and querying based on user requests.

## Installation and Usage

Given the project's educational nature, it is designed to be reviewed and run within a development environment that supports C# and .NET.

1. **Clone the Repository**:
    ```
    git clone https://github.com/Itamarcohe/BoxesProject.git
    ```
2. **Navigate to the Project Directory**:
    ```
    cd BoxesProject
    ```
3. **Compile and Run** (ensure you have .NET SDK installed):
    ```
    dotnet run
    ```

## Project Structure

- **AVLTree**: Manages the balanced tree for efficient box storage and retrieval.
- **Box**: Represents individual boxes with specific dimensions and quantities.
- **Node**: A component of the AVL tree representing a single storage unit in the warehouse.

