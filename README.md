# InstancerFramework.MVC
The InstancerFramework.MVC is for creating instances of domain objects through ASP.NET MVC using FormCollection as a parameter.

# Syntax
    Model model = Instance.NewInstance<Model>(formCollection);

# Where can I get it?
Install [InstancerFramework.MVC](https://www.nuget.org/packages/InstancerFramework.MVC) from the package manager console:

    Install-Package InstancerFramework.MVC

# Example

It is important to use __TryUpdateModel <Product> (product);__ To use the __ModelState.IsValid__

    public ActionResult Create(FormCollection formCollection)
    {
        Product product = Instance.NewInstance<Product>(formCollection);

        TryUpdateModel<Product>(product);

        if (ModelState.IsValid)
        {
            db.Products.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(product);
    }
    
