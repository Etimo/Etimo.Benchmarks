param($installPath, $toolsPath, $package, $project)
 
$dataFile = $project.ProjectItems.Item("Content").Item("Etimo.Benchmarks").Item("Data").ProjectItems.Item("The World Bank - GDP Per Capita.csv")
 
$dataFile.Properties.Item("CopyToOutputDirectory").Value = 1