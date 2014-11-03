using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ObjectHolder
/// </summary>
public class ObjectHolder
{
    private static ObjectHolder instance;
    private ObjectHolder() { }

    public static ObjectHolder Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ObjectHolder();
            }
            return instance;
        }
    }

    private UcController ucController;

    public UcController UcController
    {
        get { return ucController; }
        set { ucController = value; }
    }
}