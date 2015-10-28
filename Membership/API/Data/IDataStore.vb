Public Interface IDataStore
    ''' <summary>
    ''' Initializes the data store.
    ''' </summary>
    ''' <param name="manager">The data manager for this data store.</param>
    ''' <param name="param">A MaybeOption containing the parameters for initialization.</param>
    Sub init(manager As DataManager, param As MaybeOption(Of Object))
    Sub load()
    Sub save()
    Sub close()
End Interface
