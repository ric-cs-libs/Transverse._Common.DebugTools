using System.Text.Json; 
using System.Text.Json.Serialization; //Pour ReferenceHandler
using System.Text.Encodings.Web; //pour JavaScriptEncoder
using System.Text.Unicode; //pour UnicodeRanges

using Newtonsoft.Json;

namespace Transverse._Common.DebugTools;

public static class Debug
{
    public static void ShowData(object data)
    {
        Console.WriteLine(GetSerializedData(data, true));
    }

    //Uses Newtonsoft.Json
    public static string GetSerializedData(object data, bool indented = false)
    {
        Formatting formatting = (indented) ? Formatting.Indented : Formatting.None;
        var options = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore //Ignore le membre pointant vers une référence déjà scannée
        };

        var retour = JsonConvert.SerializeObject(data, formatting, options);

        return retour;
    }

    //Uses System.Text.Json
    public static string GetSerializedData2(object data, bool indented = false)
    {
        var options = new JsonSerializerOptions() 
        {
            WriteIndented = indented,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All), //pour ne pas avoir de souci de jeu de caractères
            ReferenceHandler = ReferenceHandler.IgnoreCycles //Garde le membre qui pointait vers une référence déjà scannée mais lui donne la valeur null  (existe depuis .net6)
            //ReferenceHandler = ReferenceHandler.Preserve //Garde le membre qui pointe vers une référence déjà scannée mais lui donne une valeur $id, correspondant a un id virtuellement ajouté à l'objet pointé   (existe depuis .net6)
        };

        var retour = System.Text.Json.JsonSerializer.Serialize(data, options);

        return retour;
    }
}
