## Usage

Open the sample scene. When you enter play mode, 4 behaviours will be demonstrated.

## Explanation 

Using this, you can trace why the best practice for initialization of an object is always

1. In a function
2. Protected by an "initialized" boolean (this is not demonstrated here, but see below)
3. Called from Awake
4. Called before any function which requires the script to be initialized in case the script is not enabled by default in the hierarchy

The initialization bool is important, because otherwise you will get double initializations. This is not demonstrated in this sample.

You can also test the "DoSomething" with/without faults from outside play mode.