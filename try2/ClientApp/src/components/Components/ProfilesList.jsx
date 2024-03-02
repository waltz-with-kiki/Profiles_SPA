import {useState} from "react";
import ProfileItem from "./ProfileItem";
import "./ProfilePage.css";

const ProfilesList = (props) => {

    return(
        <div className="profiles-list">
            {props.profiles.map((profile) =>
            <ProfileItem profile={profile} key={profile.id}></ProfileItem>) }
        </div>
    );
}

export default ProfilesList;