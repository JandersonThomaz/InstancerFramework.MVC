# InstancerFramework.MVC
The InstancerFramework serves to create instances of domain objects through the ASP.NET MVC FormCollection

# Sintaxe
    Model model = Instance.NewInstance<Model>(formCollection);

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
    
