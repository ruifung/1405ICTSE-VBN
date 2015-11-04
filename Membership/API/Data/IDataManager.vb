Public Interface IDataManager(Of T As {Class, IDataElement})
    ''' <summary>
    ''' Add a new entry.
    ''' ID may be ignored based on storage backend.
    ''' </summary>
    ''' <param name="entry">Entry to add</param>
    ''' <returns>Some(IMember) if succeeded. Else None.</returns>
    Function addEntry(entry As T) As MaybeOption(Of T)

    ''' <summary>
    ''' Updates member data.
    ''' Member must be valid member.
    ''' </summary>
    ''' <param name="entry">Entry to update.</param>
    ''' <returns>If member was successfully updated.</returns>
    Function updateEntry(entry As T) As Boolean

    ''' <summary>
    ''' Removes a member.
    ''' Member must be valid.
    ''' </summary>
    ''' <param name="entry">Entry to remove.</param>
    ''' <returns>If member was successfully removed.</returns>
    Function removeEntry(entry As T) As Boolean

    ''' <summary>
    ''' Gets the entry associated with that ID
    ''' </summary>
    ''' <param name="id">ID to get</param>
    ''' <returns></returns>
    Function getEntry(id As Integer) As MaybeOption(Of T)

    ''' <summary>
    ''' Searches the database for matching members.
    ''' </summary>
    ''' <param name="searchParam">IMember instance containing parameters to match.</param>
    ''' <param name="matchAll">Match all fields where applicable.</param>
    ''' <param name="fuzzyMatching">Allows partial matches in fields where applicable.</param>
    ''' <returns></returns>
    Function search(searchParam As T, matchAll As Boolean, fuzzyMatching As Boolean) As List(Of T)

    ''' <summary>
    ''' List all entries.
    ''' </summary>
    ''' <returns>A List containing all entries.</returns>
    Function list() As List(Of T)

    Sub init()
    Sub load()
    Sub save()
End Interface
