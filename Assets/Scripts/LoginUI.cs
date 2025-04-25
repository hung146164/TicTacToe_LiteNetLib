using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
public class LoginUI : MonoBehaviour
{
    private Button _loginButton;
    TMP_InputField _usernameInput;
    TMP_InputField _passwordInput;

    private string _username;
    private string _password;

    private TMP_Text _usernameWarn;
    private TMP_Text _passwordWarn;

    private bool _isvalidUsername = false;
    private bool _isvalidPassword = false;

    private void Awake()
    {
        _loginButton = transform.Find("Login").GetComponent<Button>();

        _usernameInput = transform.Find("UsernameInput").GetComponent<TMP_InputField>();
        _usernameInput.onValueChanged.AddListener(UsernameUpdate);
        _usernameWarn = transform.Find("UsernameWarn").GetComponent<TMP_Text>();

        _passwordInput = transform.Find("PasswordInput").GetComponent<TMP_InputField>();
        _passwordInput.onValueChanged.AddListener(PasswordUpdate);
        _passwordInput.contentType= TMP_InputField.ContentType.Password;
        _passwordWarn = transform.Find("PasswordWarn").GetComponent<TMP_Text>();

        

        _loginButton.onClick.AddListener(Login);
    }
    //Username
    private void UsernameUpdate(string val)
    {
        _username = val;
        if(!IsValidUsername(val))
        {
            _isvalidUsername = false; 
            _usernameWarn.gameObject.SetActive(true);
        }
        else
        {
            _isvalidUsername = true;
            _usernameWarn.gameObject.SetActive(false);
        }
        EnableLoginButton();
    }
    public static bool IsValidUsername(string username)
    {
        // Username: 3–16 ký tự, chỉ gồm a-z, A-Z, 0-9 và _
        string pattern = @"^[a-zA-Z0-9_]{4,16}$";
        return Regex.IsMatch(username, pattern);
    }
    //Password
    private void PasswordUpdate(string val)
    {
        _password = val;
        if (!IsValidPassword(val))
        {
            _isvalidPassword = false;
            _passwordWarn.gameObject.SetActive(true);
        }
        else
        {
            _isvalidPassword = true;
            _passwordWarn.gameObject.SetActive(false);
        }
        EnableLoginButton();
    }
    public static bool IsValidPassword(string password)
    {
        // Tối thiểu 8 ký tự, ít nhất 1 chữ hoa và 1 ký tự đặc biệt, không chứa unicode hay khoảng trắng
        string pattern = @"^(?=.*[A-Z])(?=.*[!@#$%^&*()\[\]{}\-_+=:;,.<>?/])[a-zA-Z0-9!@#$%^&*()\[\]{}\-_+=:;,.<>?/]{8,20}$";
        return Regex.IsMatch(password, pattern);
    }

    private void EnableLoginButton()
    {
        var image = _loginButton.GetComponent<Image>();
        var color = image.color;

        if (_isvalidPassword && _isvalidUsername)
        {
            _loginButton.interactable = true;
            color.a = 1f; 
        }
        else
        {
            _loginButton.interactable = false;
            color.a = 0.3f; 
        }

        image.color = color;
    }

    private void Login()
    {
        Debug.Log("Connecting to server!");
        NetworkClient.Instance.Connect();
    }
    private void Send()
    {
        Debug.Log("Sending message to the server!");
        NetworkClient.Instance.SendServer("hello there!");
    }
    
    
}