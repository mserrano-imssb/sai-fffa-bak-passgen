// Solicitar fecha de respaldo del archivo de Farmacia
string fechaFarmacia = SolicitarFecha("Dame la fecha de respaldo del archivo de Farmacia en YYYYMMDD");

// Generar la contraseña con el prefijo "FAR_"
string passwordFarmacia = GenerarPassword(fechaFarmacia, "FAR_");
Console.WriteLine($"La contraseña generada para Farmacia es: {passwordFarmacia}");

// Solicitar fecha de respaldo del archivo de Almacén
string fechaAlmacen = SolicitarFecha("Dame la fecha de respaldo del archivo de Almacen en YYYYMMDD");

// Generar la contraseña con el prefijo "AUM_"
string passwordAlmacen = GenerarPassword(fechaAlmacen, "AUM_");
Console.WriteLine($"La contraseña generada para Almacén es: {passwordAlmacen}");

// Mensaje final
Console.WriteLine("Presione enter para cerrar la aplicación.");
Console.ReadLine();

string SolicitarFecha(string mensaje)
{
    string inputDate;
    DateTime date;

    while (true)
    {
        Console.WriteLine(mensaje);
        inputDate = Console.ReadLine();

        // Validar si la entrada no es nula o vacía
        if (string.IsNullOrEmpty(inputDate))
        {
            Console.WriteLine("Error: No se ingresó una fecha. Inténtelo nuevamente.");
            continue;
        }

        // Validar que la longitud sea de 8 caracteres
        if (inputDate.Length != 8)
        {
            Console.WriteLine("Error: La fecha debe tener exactamente 8 caracteres en formato YYYYMMDD.");
            continue;
        }

        // Validar que la fecha tenga el formato correcto y sea válida
        if (!DateTime.TryParseExact(inputDate, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out date))
        {
            Console.WriteLine("Error: El formato de fecha es inválido o la fecha no existe. Inténtelo nuevamente.");
            continue;
        }

        // Si pasa todas las validaciones, regresar la fecha
        break;
    }

    return inputDate;
}

string GenerarPassword(string inputDate, string prefijo)
{
    // Primer factor clave
    string factorClave = "R3$9@1D0";

    // Descomponer la fecha YYYYMMdd
    string year = inputDate.Substring(0, 4);
    string month = inputDate.Substring(4, 2);
    string day = inputDate.Substring(6, 2);

    // Generar el password combinando factor clave y la fecha
    string password = $"{factorClave[0]}{year[0]}{factorClave[1]}{year[1]}{factorClave[2]}{year[2]}{factorClave[3]}{year[3]}{factorClave[4]}{month[0]}{factorClave[5]}{month[1]}{factorClave[6]}{day[0]}{factorClave[7]}{day[1]}";

    // Devolver el password con el prefijo indicado
    return prefijo + password;
}
