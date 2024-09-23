# Welcome to **DataHelpers** 🚀

> *please visit the end of the page for program conventions.*

## DataHelpers - How to use:
- Using the library is very simple, all you need to do is download it and add it to the project you want to work with the library on,
  right-click that project, and add "DataHelpers" as a reference.
- To use a specific class from the library, go to the top of the code and write **using.ClassName**.
  For example:
  ```csharp
   using System;
   using DataHelpers;

   namespace YourClass
   {
       public class Class
       {
          int length = 10;
          var circularStack = new CircularStack<int>(length);
          circularStack.Push(30);
          int temp1 = circularStack.Pop();
          int temp2 = circularStack.Peek();
          Console.WriteLine(Math.Max(temp1, temp2));
       }
   }
  ```
---

**DataHelpers** is here to solve the tricky, everyday problems that many programmers face while using C#. 

You might often find yourself spending hours on tasks that don’t have simple solutions, such as managing complex collections, navigating through specific algorithms, or writing custom utilities to improve performance. That’s where **DataHelpers** comes in! 💡

With **DataHelpers**, we take care of these problems under the hood with new data structures and helper functions. All you need to do is call a simple function, and we’ll handle the rest for you!

Our goal is to keep your code clean, simple, and efficient, while **we** manage the hard stuff. 😉

---

## How Does It Work?

Imagine you need to manage a custom data structure that C# doesn't natively support. Instead of reinventing the wheel every time, you can simply rely on **DataHelpers** to provide a clean, easy-to-use interface while we do the complex stuff behind the scenes.

- **Simple APIs**: Just call the functions! No need to understand the intricate details.
- **Optimized for Performance**: We ensure that everything runs smoothly and efficiently.
- **Modular Design**: Easily integrate new data structures into your project.

---

## How to Add Your Own Class to the Library 📚

Want to contribute or add your custom class to the **DataHelpers** library? Great! Here’s a simple step-by-step tutorial:

### Step 1: Fork the Repo

1. Navigate to the **DataHelpers** GitHub repository.
2. Click on the **Fork** button at the top right of the screen to create a copy of the repository under your own account.

### Step 2: Clone the Repo Locally

Once you’ve forked the repo:

1. Open a terminal or Git client.
2. Run the following command to clone your fork locally:

   ```bash
   git clone https://github.com/yourusername/DataHelpers.git
   ```
### Step 3: Create a New Class 🛠️

1. Inside the `src` folder, create a new class file for your data structure or helper function. Name it something meaningful, for example: `MyCustomStructure.cs`.

2. Add your class definition to the file. Make sure your class is well-documented using XML comments for easy integration into the library's documentation.

   ```csharp
   /// <summary>
   /// A custom data structure that solves a specific problem.
   /// </summary>
   public class MyCustomStructure
   {
       // Your custom logic here
   }
   ```
### Step 5: Create a Pull Request (PR) 📝

1. Go back to the **DataHelpers** GitHub page.
2. You’ll see an option to create a pull request. Click on it.
3. Add a meaningful title and description to your PR and submit it for review.

Once your pull request is approved and merged, your class will be a part of the **DataHelpers** library! 🎉
## Program Conventions 🤝👨‍💻:
   - ### Changing or adding code to an existing class in the library:
     - If you want to add a function, a parameter, a constructor, etc.
       Just add the code to the existing C# file and create a pull request.
     - Note that if you delete any existing code or change it in any way, you will have to explain why it benefits
       the existing code and we will determine whether to apply those changes or not.
   - ### Adding a new class into the library:
     - In the **DataHelpers.csproj**, create a new folder with the same name as the class you want to create,
       in there, put all the items you created for your own created class with the actual class itself.
     - If you want to add an exception with a special name for your class, add that Exception class inside **DataHelpersException.cs**.
   - ### All added items need to have proper XML documentation [and comments describing the code] (if needed)
### **Pull requests that will not meet the mentioned conditions WILL NOT be accepted into the library**
