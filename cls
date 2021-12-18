[1mdiff --git a/.editorconfig b/.editorconfig[m
[1mnew file mode 100644[m
[1mindex 0000000..ce15965[m
[1m--- /dev/null[m
[1m+++ b/.editorconfig[m
[36m@@ -0,0 +1,4 @@[m
[32m+[m[32m﻿[*.cs][m
[32m+[m
[32m+[m[32m# IDE0059: Unnecessary assignment of a value[m
[32m+[m[32mdotnet_diagnostic.IDE0059.severity = silent[m
[1mdiff --git a/.vs/GoldBadgeChallengesFinal/v16/.suo b/.vs/GoldBadgeChallengesFinal/v16/.suo[m
[1mindex 0eb5275..a3a3a6c 100644[m
Binary files a/.vs/GoldBadgeChallengesFinal/v16/.suo and b/.vs/GoldBadgeChallengesFinal/v16/.suo differ
[1mdiff --git a/.vs/GoldBadgeChallengesFinal/v16/TestStore/0/000.testlog b/.vs/GoldBadgeChallengesFinal/v16/TestStore/0/000.testlog[m
[1mindex 698179b..a19b1cf 100644[m
Binary files a/.vs/GoldBadgeChallengesFinal/v16/TestStore/0/000.testlog and b/.vs/GoldBadgeChallengesFinal/v16/TestStore/0/000.testlog differ
[1mdiff --git a/.vs/ProjectSettings.json b/.vs/ProjectSettings.json[m
[1mnew file mode 100644[m
[1mindex 0000000..f8b4888[m
[1m--- /dev/null[m
[1m+++ b/.vs/ProjectSettings.json[m
[36m@@ -0,0 +1,3 @@[m
[32m+[m[32m{[m
[32m+[m[32m  "CurrentProjectSetting": null[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/.vs/VSWorkspaceState.json b/.vs/VSWorkspaceState.json[m
[1mnew file mode 100644[m
[1mindex 0000000..fbd2d33[m
[1m--- /dev/null[m
[1m+++ b/.vs/VSWorkspaceState.json[m
[36m@@ -0,0 +1,7 @@[m
[32m+[m[32m{[m
[32m+[m[32m  "ExpandedNodes": [[m
[32m+[m[32m    ""[m
[32m+[m[32m  ],[m
[32m+[m[32m  "SelectedNode": "\\GoldBadgeChallengesFinal.sln",[m
[32m+[m[32m  "PreviewInSolutionExplorer": false[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/.vs/slnx.sqlite b/.vs/slnx.sqlite[m
[1mnew file mode 100644[m
[1mindex 0000000..2855afd[m
Binary files /dev/null and b/.vs/slnx.sqlite differ
[1mdiff --git a/ChallengeOneCafe.POCO/ChallengeOneCafe.POCO.csproj b/ChallengeOneCafe.POCO/ChallengeOneCafe.POCO.csproj[m
[1mindex 663e6e7..4e2167c 100644[m
[1m--- a/ChallengeOneCafe.POCO/ChallengeOneCafe.POCO.csproj[m
[1m+++ b/ChallengeOneCafe.POCO/ChallengeOneCafe.POCO.csproj[m
[36m@@ -41,7 +41,7 @@[m
     <Reference Include="System.Xml" />[m
   </ItemGroup>[m
   <ItemGroup>[m
[31m-    <Compile Include="Menu.cs" />[m
[32m+[m[32m    <Compile Include="MenuItem.cs" />[m
     <Compile Include="Properties\AssemblyInfo.cs" />[m
   </ItemGroup>[m
   <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />[m
[1mdiff --git a/ChallengeOneCafe.POCO/MenuItem.cs b/ChallengeOneCafe.POCO/MenuItem.cs[m
[1mindex e376b46..32a45d8 100644[m
[1m--- a/ChallengeOneCafe.POCO/MenuItem.cs[m
[1m+++ b/ChallengeOneCafe.POCO/MenuItem.cs[m
[36m@@ -6,8 +6,60 @@[m [musing System.Threading.Tasks;[m
 [m
 namespace ChallengeOneCafe.POCO[m
 {[m
[31m-    public class Menu[m
[32m+[m[32m    public class MenuItem[m
     {[m
[31m-        // Properties: MealNumber, MealName, Description, List of Ingredients, Pricing[m
[32m+[m[32m        //Empty[m
[32m+[m[32m        public MenuItem() { }[m
[32m+[m[32m        //Hard Code Entry[m
[32m+[m[32m        public MenuItem(int mealNumber, string mealName, string mealDescription, string mainIngredient, List<string> sideIngredients, decimal mealPrice, bool isAvailable)[m
[32m+[m[32m        {[m
[32m+[m[32m            MealNumber = mealNumber;[m
[32m+[m[32m            MealName = mealName;[m
[32m+[m[32m            MealDescription = mealDescription;[m
[32m+[m[32m            MainIngredient = mainIngredient;[m
[32m+[m[32m            SideIngredients = sideIngredients;[m
[32m+[m[32m            MealPrice = mealPrice;[m
[32m+[m[32m            IsAvailable = isAvailable;[m
[32m+[m[32m        }[m
[32m+[m[32m        //Use function to assign meal number[m
[32m+[m[32m        public MenuItem(string mealName, string mealDescription, string mainIngredient, List<string> sideIngredients, decimal mealPrice, bool isAvailable)[m
[32m+[m[32m        {[m
[32m+[m[32m            MealName = mealName;[m
[32m+[m[32m            MealDescription = mealDescription;[m
[32m+[m[32m            MainIngredient = mainIngredient;[m
[32m+[m[32m            SideIngredients = sideIngredients;[m
[32m+[m[32m            MealPrice = mealPrice;[m
[32m+[m[32m            IsAvailable = isAvailable;[m
[32m+[m[32m        }[m
[32m+[m[32m        //Use function to assign meal number and leave the mealPrice null? (blank to where price could be added later)[m
[32m+[m[32m        public MenuItem(string mealName, string mealDescription, string mainIngredient, List<string> sideIngredients, bool isAvailable)[m
[32m+[m[32m        {[m
[32m+[m[32m            MealName = mealName;[m
[32m+[m[32m            MealDescription = mealDescription;[m
[32m+[m[32m            MainIngredient = mainIngredient;[m
[32m+[m[32m            SideIngredients = sideIngredients;[m
[32m+[m[32m            IsAvailable = isAvailable;[m
[32m+[m[32m        }[m
[32m+[m[32m        //Use function to assign meal number for an item coming soon[m
[32m+[m[32m        public MenuItem(string mealName, string mealDescription, string mainIngredient, bool isAvailable)[m
[32m+[m[32m        {[m
[32m+[m[32m            MealName = mealName;[m
[32m+[m[32m            MealDescription = mealDescription;[m
[32m+[m[32m            MainIngredient = mainIngredient;[m
[32m+[m[32m            IsAvailable = isAvailable;[m
[32m+[m[32m        }[m
[32m+[m[32m        //Use function to assign meal number and only enter the name (Could be for like an idea for a menu item in early concept)[m
[32m+[m[32m        public MenuItem(string mealName, bool isAvailable)[m
[32m+[m[32m        {[m
[32m+[m[32m            MealName = mealName;[m
[32m+[m[32m            IsAvailable = isAvailable;[m
[32m+[m[32m        }[m
[32m+[m[32m        public int MealNumber { get; set; }[m
[32m+[m[32m        public string MealName { get; set; }[m
[32m+[m[32m        public string MealDescription { get; set; }[m
[32m+[m[32m        public string MainIngredient { get; set; }[m
[32m+[m[32m        public List<string> SideIngredients { get; set; }[m
[32m+[m[32m        public decimal MealPrice { get; set; }[m
[32m+[m[32m        public bool IsAvailable { get; set; }[m
     }[m
 }[m
[1mdiff --git a/ChallengeOneCafe.POCO/bin/Debug/ChallengeOneCafe.POCO.dll b/ChallengeOneCafe.POCO/bin/Debug/ChallengeOneCafe.POCO.dll[m
[1mnew file mode 100644[m
[1mindex 0000000..e6ac1f4[m
Binary files /dev/null and b/ChallengeOneCafe.POCO/bin/Debug/ChallengeOneCafe.POCO.dll differ
[1mdiff --git a/ChallengeOneCafe.POCO/bin/Debug/ChallengeOneCafe.POCO.pdb b/ChallengeOneCafe.POCO/bin/Debug/ChallengeOneCafe.POCO.pdb[m
[1mnew file mode 100644[m
[1mindex 0000000..c2aadfd[m
Binary files /dev/null and b/ChallengeOneCafe.POCO/bin/Debug/ChallengeOneCafe.POCO.pdb differ
[1mdiff --git a/ChallengeOneCafe.POCO/obj/Debug/ChallengeOneCafe.POCO.csproj.AssemblyReference.cache b/ChallengeOneCafe.POCO/obj/Debug/ChallengeOneCafe.POCO.csproj.AssemblyReference.cache[m
[1mindex b77aaf9..f5e894a 100644[m
Binary files a/ChallengeOneCafe.POCO/obj/Debug/ChallengeOneCafe.POCO.csproj.AssemblyReference.cache and b/ChallengeOneCafe.POCO/obj/Debug/ChallengeOneCafe.POCO.csproj.AssemblyReference.cache differ
[1mdiff --git a/ChallengeOneCafe.POCO/obj/Debug/ChallengeOneCafe.POCO.csproj.CoreCompileInputs.cache b/ChallengeOneCafe.POCO/obj/Debug/ChallengeOneCafe.POCO.csproj.CoreCompileInputs.cache[m
[1mnew file mode 100644[m
[1mindex 0000000..00a9f71[m
[1m--- /dev/null[m
[1m+++ b/ChallengeOneCafe.POCO/obj/Debug/ChallengeOneCafe.POCO.csproj.CoreCompileInputs.cache[m
[36m@@ -0,0 +1 @@[m
[32m+[m[32m44c3efcf2ee24a779ea513911cf424250f05ae29[m
[1mdiff --git a/ChallengeOneCafe.POCO/obj/Debug/ChallengeOneCafe.POCO.csproj.FileListAbsolute.txt b/ChallengeOneCafe.POCO/obj/Debug/ChallengeOneCafe.POCO.csproj.FileListAbsolute.txt[m
[1mnew file mode 100644[m
[1mindex 0000000..bf1d68c[m
[1m--- /dev/null[m
[1m+++ b/ChallengeOneCafe.POCO/obj/Debug/