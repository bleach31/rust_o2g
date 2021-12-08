
`dotnet run`

dotnet build

dotnet --info


dotnet publish /t:LinkNative /p:NativeLib=Static -c Release -r win-x64


    <OutputType>Library</OutputType>
    
    <OutputType>Exe</OutputType>


dotnet add package Microsoft.DotNet.ILCompiler.SDK --version 1.0.5-prerelease-00002 --source https://www.myget.org/F/dotnet/api/v3/index.json

dotnet add package Microsoft.DotNet.ILCompiler.SDK --version 1.0.5-prerelease-00002 

文字化け
chcp65001