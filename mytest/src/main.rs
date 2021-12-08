#[link(name = "bootstrapperdll", kind = "static")] 
#[link(name = "Runtime", kind = "static")]
#[link(name = "scharp", kind = "static")]
extern "C" {
    pub fn add_dotnet(a: i32, b: i32) -> i32;
}

fn main() {
    unsafe{
        println!("Hello, world!");
        let result = add_dotnet(1, 2);
        println!("{}", result);
    }
}
