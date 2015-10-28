Public Interface IDataStore
    Sub init(manager As DataManager)
    Sub load()
    Sub save()
    Sub close()
End Interface
