import { Button, Dialog, DialogTitle, TextField } from "@mui/material";
import { useState } from "react";
import { login as loginService } from "../services/loginService";

interface IProps {
    open: boolean,
    handlePopupClose: () => void
}

export const LoginPopup = (props: IProps) => {
    const [login, setLogin] = useState<string>('');
    const [pass, setPass] = useState<string>('');

    return (
        <Dialog maxWidth="lg" onClose={() => props.handlePopupClose()} open={props.open}>
            <DialogTitle>Login</DialogTitle>
            <div className="LoginForm">
                <TextField
                    style={{width: '300px'}}
                    id="outlined-disabled"
                    label="Login"
                    onChange={(e) => setLogin(e.target.value)}
                />
                <TextField
                    id="outlined-password-input"
                    label="Password"
                    type="password"
                    autoComplete="current-password"
                    onChange={(e) => setPass(e.target.value)}
                />
                <Button
                    style={{ backgroundColor: "#282c34" }}
                    variant="contained"
                    onClick={async () => {
                        const logging = await loginService(login, pass);
                        
                        if (logging) {
                            props.handlePopupClose();
                        }
                    }}
                >
                    Login
                </Button>
            </div>
        </Dialog>
    )
};