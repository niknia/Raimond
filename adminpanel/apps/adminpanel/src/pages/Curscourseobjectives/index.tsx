import { BasePage } from '@/components/layouts/BasePage';
import React, { useEffect, useState, useMemo } from 'react';
import { Stack, Box, Title, Text, Button, Group, Modal, TextInput } from '@mantine/core';
import { useCurScourseobjectives } from '@/data/curscourseobjectives/curscourseobjectives.query';
import { DkdGrid } from '@dkd-grid';
import type { ColumnDef } from '@tanstack/react-table';
import type { CurScourseobjectivesDto } from '@/data/curscourseobjectives/curscourseobjectives.models';
import { useDisclosure } from '@mantine/hooks';
import { notifications } from '@mantine/notifications';

export default function IndexPage() {
    const { useGetAll, useCreate, useUpdate, useDelete } = useCurScourseobjectives();
    const { data: curScourseobjectivesData, isLoading, refetch } = useGetAll();
    const createMutation = useCreate();
    const updateMutation = useUpdate();
    const deleteMutation = useDelete();
    
    const [selectedRowId, setSelectedRowId] = useState<string | null>(null);
    const [editingCourseObjective, setEditingCourseObjective] = useState<CurScourseobjectivesDto | null>(null);
    const [opened, { open, close }] = useDisclosure(false);

    const data = curScourseobjectivesData?.result || [];

    // تعریف ستون‌های جدول
    const columns = useMemo<ColumnDef<CurScourseobjectivesDto>[]>(() => [
        {
            accessorKey: 'id',
            header: 'شناسه',
            size: 80,
        },
        {
            accessorKey: 'name',
            header: 'نام هدف دوره',
            size: 200,
        },
        {
            accessorKey: 'createTime',
            header: 'تاریخ ایجاد',
            size: 150,
            cell: ({ getValue }: { getValue: () => any }) => {
                const date = getValue() as string;
                return date ? new Date(date).toLocaleDateString('fa-IR') : '-';
            },
        },
    ], []);

    // هندل‌های CRUD
    const handleEdit = (row: CurScourseobjectivesDto) => {
        setEditingCourseObjective(row);
        open();
    };

    const handleDelete = async (row: CurScourseobjectivesDto) => {
        try {
            await deleteMutation.mutateAsync(row.id);
            notifications.show({
                title: 'موفقیت',
                message: 'هدف دوره با موفقیت حذف شد',
                color: 'green',
            });
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در حذف هدف دوره',
                color: 'red',
            });
        }
    };

    const handleAdd = () => {
        setEditingCourseObjective(null);
        open();
    };

    const handleSave = async (values: Partial<CurScourseobjectivesDto>) => {
        try {
            if (editingCourseObjective) {
                await updateMutation.mutateAsync({ id: editingCourseObjective.id, ...values });
                notifications.show({
                    title: 'موفقیت',
                    message: 'هدف دوره با موفقیت ویرایش شد',
                    color: 'green',
                });
            } else {
                await createMutation.mutateAsync(values);
                notifications.show({
                    title: 'موفقیت',
                    message: 'هدف دوره جدید با موفقیت ایجاد شد',
                    color: 'green',
                });
            }
            close();
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در ذخیره‌سازی',
                color: 'red',
            });
        }
    };

    return (
        <BasePage>
            <Stack gap="lg">
                <Box>
                    <Title order={2}>مدیریت اهداف دوره</Title>
                    <Text c="dimmed">مدیریت اهداف مختلف دوره‌های آموزشی</Text>
                </Box>

                <DkdGrid
                    columns={columns}
                    data={data}
                    isLoading={isLoading}
                    rtl
                    height={600}
                    selectedRowId={selectedRowId}
                    onRowClick={(row: any) => setSelectedRowId(row.original.id.toString())}
                    onEdit={handleEdit}
                    onDelete={handleDelete}
                    onAdd={handleAdd}
                    initialPageSize={15}
                />

                {/* Modal برای افزودن/ویرایش */}
                <Modal 
                    opened={opened} 
                    onClose={close} 
                    title={editingCourseObjective ? 'ویرایش هدف دوره' : 'افزودن هدف دوره جدید'}
                    size="md"
                >
                    <Stack gap="md">
                        <TextInput
                            label="نام هدف دوره"
                            placeholder="نام هدف دوره"
                            defaultValue={editingCourseObjective?.name || ''}
                            name="name"
                            required
                        />
                        
                        <Group justify="flex-end" mt="md">
                            <Button variant="outline" onClick={close}>
                                انصراف
                            </Button>
                            <Button 
                                onClick={() => {
                                    const formData = new FormData(document.querySelector('form') as HTMLFormElement);
                                    const values = {
                                        name: (formData.get('name') as string) || '',
                                    };
                                    handleSave(values);
                                }}
                                loading={createMutation.isPending || updateMutation.isPending}
                            >
                                {editingCourseObjective ? 'ویرایش' : 'افزودن'}
                            </Button>
                        </Group>
                    </Stack>
                </Modal>
            </Stack>
        </BasePage>
    );
} 