# Setup for local development
* Clone the [perception](https://github.com/Unity-Technologies/com.unity.perception) repository into an arbirary directory on disk
* Install and use Unity latest [2019.3 Unity editor](https://unity3d.com/unity/beta/2019.3#downloads) 

## Setting up a Project
Down below are 2 options for getting started using the Perception SDK, Option 1 is opening existing test projects in the repository. Option 2 a guide on how to create a new 
Unity project and intergrate the Perception SDK

### Option 1: PerceptionHDRP & PerceptionURP Projects
The repository includes two projects for local development in `TestProjects` folder, one set up for HDRP and the other for URP. You can open these with the Unity
editor you installed in Setup instructions.

### Option 2: Create a new Project 
These option is walkthrough in creating a new project, then adding the Perception SDK package to the project for development use.
*The following instructions reference the Unity doc's page on [installing a local package](https://docs.unity3d.com/Manual/upm-ui-local.html)*

#### Create a new project 
1. Create a new HDRP project or open an existing project
	1. Creating anew HDRP project can be done by creating a new project using the HDRP template 
2. Navigate to the root of your project and open your project's `<project root>/Packages/manifest.json` in a text editor
3. At the end of the file, add `"registry": "https://artifactory.prd.cds.internal.unity3d.com/artifactory/api/npm/upm-candidates"`
    1. _Note: This step will be removed once the dependency `com.unity.entities-0.2.0-preview.*` is published publically._
4. Back in Unity editor, got Window ->  Package Manager
	1. Add the High Definition RP package, version 7.1.2 or later from the packages list 
	2. In the Package Manager window find and click the ***+*** button in the upper lefthand corner of the window
	3. Select the ***add package from disk*** option
	4. Navigate to the com.unity.perception folder in your cloned repository and select the package.json file
5. Navigate to the root of your project and open your project's `<project root>/Packages/manifest.json` in a text editor
	1. To allow the compilation and running of tests, add `"testables": [ "com.unity.perception" ]` 
    2. For an example `manifest.json`, see `TestProjects/PerceptionTest/Packages/manifest.json`
    3. For more on the `manifest.json` schema, see the [Package Manager documentation](https://docs.unity3d.com/Packages/com.unity.package-manager-ui@1.7/manual/index.html#advanced-package-topics)
6. Once you have a project with Perception SDK installed you can move forward to the Getting Started walkthrough 

## Suggested IDE Setup
For closest standards conformity and best experience overall, JetBrains Rider or Visual Studio w/ JetBrains Resharper are suggested. For optimal experience, perform the following additional steps:
* To allow navigating to code in all packages included in your project, in your Unity Editor, navigate to `Edit -> Preferences... -> External Tools` and check `Generate all .csproj files.` 
* To get automatic feedback and fixups on formatting and naming convention violations, set up Rider/JetBrains with our Unity standard .dotsettings file by following [these instructions](https://github.cds.internal.unity3d.com/unity/com.unity.coding/tree/master/UnityCoding/Packages/com.unity.coding/Coding~/Configs/JetBrains).
* If you use VS Code, install the Editorconfig extension to get automatic code formatting according to our convention