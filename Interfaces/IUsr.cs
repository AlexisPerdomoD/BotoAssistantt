namespace Boto.interfaces;

/// <summary>
///   Interface for a user that can be used by the main program
/// </summary>
/// <remarks>
///   A user is a class that implements this interface and has a Name, a Profile and a list of Tags
/// </remarks>
public interface IUsr
{
    string Name { get; }
    string UsrProfile { get; set; }
    DateTime LastLogin { get; set; }
    string[] ProfileTags { get; set; }

    /// <summary>
    ///   Method to load the user's STS data, usually on "${BOTO_WORKING_DIRECTORY}/usr/usr.json"
    /// </summary>
    /// <param name="usr"></param>
    /// <returns>error message if any, else null</returns>
    Task<string?> SaveUsrSts();
}

/// <summary>
///   Interface for a user manager that can be used by the main program
/// </summary>
/// <remarks>
///   A user manager is able to verify if a user exists, create a new user and get the current user
/// </remarks>
public interface IUsrMannager
{
    Task<(Exception? e, IUsr? usr)> UsrExists(string usrName);
    Task<(Exception? e, IUsr? usr)> CreateUsr(
        string usrName,
        string usrProfile,
        string[] profileTags
    );
    IUsr? GetCurrentUsr();
    Task<bool> SetCurrentUsr(IUsr? usr);
}