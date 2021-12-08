
fn main() {
    println!("cargo:rustc-link-search=native={}", "./lib");
    println!("cargo:rustc-link-search=native={}", "C:/Users/{***Change***}/.nuget/packages/runtime.win-x64.microsoft.dotnet.ilcompiler/6.0.0-rc.1.21420.1/sdk");
}