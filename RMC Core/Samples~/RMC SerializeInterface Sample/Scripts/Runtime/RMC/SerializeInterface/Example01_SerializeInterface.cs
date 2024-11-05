using UnityEngine;

namespace RMC.Core.Samples.SerializeInterface
{
    /// <summary>
    /// Demo of SerializeInterface
    /// </summary>
    public class Example01_SerializeInterface : MonoBehaviour
    {
        //  Fields ----------------------------------------

        [Header("Standard Unity Functionality")]

        //2. Drag-And-Drop uses class. C# uses class
        [SerializeField]
        private CubeA _cube1;

        //2. Drag-And-Drop uses class. C# uses class (which implements interface)
        [SerializeField] private CubeB _cube2;

        //HACK: I add whitespace here because something about the rendering of InterfaceReference breaks layout
        [Header("     New Custom Functionality")]

        //3. Drag-And-Drop uses interface. C# uses interface
        [SerializeField]
        private InterfaceReference<ICube> _cube3;

        //4. Drag-And-Drop uses interface. C# uses class
        [SerializeField] 
        [RequireInterface(typeof(ICube))]
        private CubeC _cube4;


        //  Unity Methods  --------------------------------
        protected void Start()
        {
            //Note: Access reference indirectly through 'Value'
            _cube3.Value.HelloWorld();

            //Note: Access reference directly
            _cube4.HelloWorld();
        }
    }
}
