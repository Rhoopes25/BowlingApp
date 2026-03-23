import { useState, useEffect } from 'react'
import type { Bowler } from '../types/bowler'

function BowlerList() {
    // State to hold the list of bowlers
    const [bowlers, setBowlers] = useState<Bowler[]>([])

    // Fetch bowlers from the API when the component first loads
    useEffect(() => {
        fetchBowlers()
    }, [])

    // Async function to fetch bowler data from the .NET API
    async function fetchBowlers() {
        const response = await fetch('http://localhost:5000/api/bowlers')
        const data = await response.json()
        setBowlers(data)
    }

    return (
        <table>
            <thead>
            <tr>
                <th>Name</th>
                <th>Team</th>
                <th>Address</th>
                <th>City</th>
                <th>State</th>
                <th>Zip</th>
                <th>Phone</th>
            </tr>
            </thead>
            <tbody>
            {bowlers.map((bowler) => (
                <tr key={bowler.bowlerID}>
                    <td>{bowler.bowlerFirstName} {bowler.bowlerMiddleInit} {bowler.bowlerLastName}</td>
                    <td>{bowler.teamName}</td>
                    <td>{bowler.bowlerAddress}</td>
                    <td>{bowler.bowlerCity}</td>
                    <td>{bowler.bowlerState}</td>
                    <td>{bowler.bowlerZip}</td>
                    <td>{bowler.bowlerPhoneNumber}</td>
                </tr>
            ))}
            </tbody>
        </table>
    )
}

export default BowlerList