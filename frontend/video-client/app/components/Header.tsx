
import React from "react";

export default function Header() {
    return (
        <header
            className="
            fixed
            top-0
            z-50
            flex
            w-full
            items-center
            justify-between
            px-4
            py-4
            lg:px-10 
            lg:py-6"

        >
            <ul>
                <li>Home</li>
                <li>TV Shows</li>
                <li>Movies</li>
                <li>Latest</li>
            </ul>
        </header>
    )

}