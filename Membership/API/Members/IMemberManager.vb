Public Interface IMemberManager
    ''' <summary>
    ''' Add a new member.
    ''' Member ID must be ignored and overridden
    ''' </summary>
    ''' <param name="member">Member to add</param>
    ''' <returns>Some(IMember) if succeeded. Else None.</returns>
    Function addMember(member As IMember) As MaybeOption(Of IMember)

    ''' <summary>
    ''' Updates member data.
    ''' Member must be valid member.
    ''' </summary>
    ''' <param name="member">Member to update.</param>
    ''' <returns>If member was successfully updated.</returns>
    Function updateMember(member As IMember) As Boolean

    ''' <summary>
    ''' Removes a member.
    ''' Member must be valid.
    ''' </summary>
    ''' <param name="member">Member to remove.</param>
    ''' <returns>If member was successfully removed.</returns>
    Function removeMember(member As IMember) As Boolean

    ''' <summary>
    ''' Searches the database for matching members.
    ''' </summary>
    ''' <param name="searchParam">IMember instance containing parameters to match.</param>
    ''' <param name="fuzzy">Allows partial matches where applicable.</param>
    ''' <returns></returns>
    Function search(searchParam As IMember, fuzzy As Boolean) As List(Of IMember)

    Sub init()
    Sub load()
    Sub save()
End Interface
