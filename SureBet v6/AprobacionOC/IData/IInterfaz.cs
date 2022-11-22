using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IData
{
    public interface IInterfaz
    {
        object Agregar(object param);
        object Editar(object param);
        object Edit_Est_Reg(object param);
        object Eliminar(object param);
        object ListarTodos(object param);
        object ListarxID(object param);
    }
}
