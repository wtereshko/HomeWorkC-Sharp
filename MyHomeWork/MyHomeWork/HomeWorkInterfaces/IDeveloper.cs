namespace MyHomeWork
{
/* Create interface IDeveloper with property Tool, methods Create() and Destroy()
Create two classes Programmer(with field language) and Builder(with field tool), 
which implement this interface.
Create List of IDeveloper and add some Programmers and Builders to it.Call Create() and Destroy() methods, 
property Tool for all of it
*/
    interface IDeveloper
    {
        string Tool { get; set; }
        void Create();
        void Destroy();

    }
}
