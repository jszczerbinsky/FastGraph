# What is FastGraph?
FastGraph is .NET 4.7 library written in C#, created for rendering line graphs for your project. You can customize style for your graph, decide about its size and values offset. FastGraph is the easiest way to generate graph from your data.

![Alt text](img/screen1.png?raw=true "screen")

## Features
* Load data from csv and specify which columns to use 
* Write data by hand
* Draw multiple nodes on one graph
* Fully customizable style for your graph
* Graph is generated as Bitmap so you can display it in your window or save it as a file
* You can adjust the size of a graph and offset between values
* You can draw asymptotes

## How to use it?
1. Create a new `Graph` instance
...

    ```C#
    Graph myFirstGraph = new Graph();
    ```
    `Graph` object stores information about axes names and offset between displayed values. Let's set our axes names to some non-default value:
    
    ```C#
    myFirstGraph.xAxisName = "My x axis";
    myFirstGraph.yAxisName = "My y axis";
    ```
    
    And set offset between values
    
    ```C#
    myFirstGraph.xPointersSpace = 1;
    myFirstGraph.yPointersSpace = 10;
    ```
    
2. Add data to your graph
    
    Create new `GraphNode` instance
    ```C#
    GraphNode node = new GraphNode("My node");
    ```
    
    Here you can put the data manually to it or load it from a csv file
    
    Manually putting data:
    
    ```C#
    node.Values.Add(new Coordinate(1, 140));
    node.Values.Add(new Coordinate(2, 95));
    node.Values.Add(new Coordinate(3, 112));
    ```
    
    Loading data from file:
        
    To load data from file you need to create `FileInput` instance and use `LoadCSV` method to load it.
    `LoadCSV` needs some arguments:
    
    >`Node` instance to load [`Node`]
    
    >Path to file [`string`]
    
    >Ignore first line in file [`bool`]
    
    >Column that stores x axis data [`int`]
    
    >Column that stores y axis data [`int`]
    
    >Separator [`char`]
        
    ```C#
    FileInput input = new FileInput();
    input.LoadCSV(node, "path/to/your/file.csv", false, 1, 2, ',');
    ```
    
    Add your node to your graph
    
    ```C#
    myFirstGraph.AddNode(node);
    ```
    
    You can create and add multiple nodes to graph 
    
3. Maybe some asymptotes?
    
    You have to specify where to put it. For example if you want asymptote on x axis on value 3 do it like this:
    ```C#
    Asymptote as = new Asymptote(Axis.X, 3);
    ```
    
    And now put it into your graph:
    ```C#
    myFirstGraph.AddAsymptote(as);
    ```
    
4. Graph styling
    
    Use ready to use styles:
    ```C#
    myFirstGraph.Style = GraphStyle.Bright;
    ```
    ```C#
    myFirstGraph.Style = GraphStyle.Classic;
    ```
    ```C#
    myFirstGraph.Style = GraphStyle.Dark;
    ```
    
    Change some things:
    ```C#
    myFirstGraph.Style.AxisPen = new Pen(new SolidBrush(Color.White), 2);
    myFirstGraph.Style.DisplayXValuePointers = false;
    myFirstGraph.ShowGrid = false;
    myFirstGraph.LeftMargin = 120;
    ```
    
    List of all `GraphStyle` parameters:
    ```C#
    int LeftMargin;
    int BottomMargin;
    int TopMargin;
    int RightMargin;

    int xValuePointerOutLength;
    int xValuePointerInLength;
    int yValuePointerOutLength;
    int yValuePointerInLength;

    int xValuePointerMargin;
    int yValuePointerMargin;

    bool ShowXAxisName;
    bool ShowYAxisName;

    bool DisplayXValuePointers;
    bool DisplayYValuePointers;

    bool DisplayXValuePointersLines;
    bool DisplayYValuePointersLines;

    bool ShowGrid;

    Pen AxisPen;
    Pen ValuePointersPen;

    Font NodeNameFont;
    Font AxisNameFont;
    Font AsymptoteFont;
    Font ValuePointersFont;

    Brush Background ;
    Brush ValuePointersTextBrush;
    Brush AxisNameBrush;
    ```

5. Rendering graph
    Now you can render your graph using `Render` function with this parameters:
    
    > x start value [`int`]
    
    > y start value [`int`]
    
    > x size (not end value!) [`int`]
    
    > y size (not end value!) [`int`]
    
    > image size [`Size`]
    
    ```C#
    Bitmap bmp = g.Render(1, 0, 10, 160, new Size(1280, 720));
    ```
