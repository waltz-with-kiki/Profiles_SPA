import React from "react";
import classes from "./MyAvatar.module.css"

    const MyAvatar = (props) => {

        return(
            <div>
                <img style={props.style} src={props.src} alt={props.alt} className={classes.avatar}></img>
            </div>
        );
    }

export default MyAvatar;