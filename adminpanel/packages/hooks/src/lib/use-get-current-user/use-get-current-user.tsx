import { getCurrentUser, to } from '@omnidash/api'
import { useStore } from '@omnidash/store'
import { AxiosError, AxiosResponse } from 'axios'
import { User } from 'next-auth'
import { useEffect } from 'react'

export const useGetCurrentUser = () => {
  const {
    user,
    actions: { setUser },
  } = useStore.use.auth()

  const handleGetCurrentUser = async () => {
    const [error, response] = await to<AxiosResponse<never, User>, AxiosError>(
      getCurrentUser()
    )

    console.log({ error, response })

    setUser(response?.data ?? null)
  }

  useEffect(() => {
    console.log({ user })
    if (!user) {
      handleGetCurrentUser()
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])
}
